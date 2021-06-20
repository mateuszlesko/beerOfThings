﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using beerOfThings.Models;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace beerOfThings.Controllers
{
    public class ProcessController : Controller
    {
        beerOfThingsContext _context;

        public ProcessController(beerOfThingsContext context) 
        {
            _context = context;
        }


        public async Task<IActionResult> Index() 
        {
            IEnumerable<WarmingHistory> histories = await _context.WarmingHistories.Include(history => history.Recipe).ToListAsync();

            return View(histories);
        }

        public IActionResult Current()
        {
           
            int recipeId = int.Parse(Request.Cookies["recipe"]);

            if (recipeId == 0)
            {
                NotFound();
            }

            List<Brewing> brewing = _context.Brewings.Include(b => b.Stage).Where(b => b.RecipeId == recipeId).ToList();

            Recipe recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeId);
            
            if (recipe == null) 
            {
                NotFound();
            }

            beerOfThings.ViewModels.ProcessDetails process = new beerOfThings.ViewModels.ProcessDetails()
            {
                recipe = recipe,
                brewing = brewing
            };
            int lastIndex = brewing.Count - 1;
            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddHours(8) };
            Response.Cookies.Append("recipe", $"{recipeId}",options);
            
            Response.Cookies.Append("endState", $"{brewing.Count}",options);
            return View(process);
        }

        public IActionResult Next() 
        {
            int current = System.Convert.ToInt32(Request.Cookies["currentState"]);
            current += 1;

            Response.Cookies.Append("currentState", "", new CookieOptions() { Expires = DateTime.Now.AddHours(-8) });
            Response.Cookies.Append("currentState", $"{current}", new CookieOptions() { Expires = DateTime.Now.AddHours(8) });

            return RedirectToAction("Current");
        }

        public IActionResult Previous()
        {
            int current = System.Convert.ToInt32(Request.Cookies["currentState"]);
            current -= 1;

            Response.Cookies.Append("currentState", "", new CookieOptions() { Expires = DateTime.Now.AddHours(-8) });
            Response.Cookies.Append("currentState", $"{current}", new CookieOptions() { Expires = DateTime.Now.AddHours(8) });

            return RedirectToAction("Current");
        }

        public async Task<ActionResult> Create() 
        {
            ViewBag.Recipes = await _context.Recipes.ToListAsync();
            RemoveCookies();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("RecipeId")] WarmingHistory warming) 
        {
            _context.WarmingHistories.Add(warming);
            await _context.SaveChangesAsync();

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddHours(8) };
            Response.Cookies.Append("recipe", $"{warming.RecipeId}",options);
            Response.Cookies.Append("currentState", $"{0}", options);

            return RedirectToAction("Index");

        }

        private void RemoveCookies() 
        {
            Response.Cookies.Append("recipe", "", new CookieOptions() { Expires = DateTime.Now.AddHours(-8) });
            Response.Cookies.Append("currentState", "", new CookieOptions() { Expires = DateTime.Now.AddHours(-8) });
            Response.Cookies.Append("endState", "", new CookieOptions() { Expires = DateTime.Now.AddHours(-8) });
        }
    }
}