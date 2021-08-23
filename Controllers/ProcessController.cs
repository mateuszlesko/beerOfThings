using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using beerOfThings.Models;

namespace beerOfThings.Controllers
{
    public class ProcessController : Controller
    {
        private BeerOfThingsContext _context;

        public ProcessController(BeerOfThingsContext context) 
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index() 
        {
            IEnumerable<WarmingHistory> histories = await _context.WarmingHistories.Include(history => history.Recipe).ToListAsync();

            return View(histories);
        }

        public async Task<IActionResult> Current()
        {
           
            int recipeId = Request.Cookies["recipe"] == null ? 0 : int.Parse(Request.Cookies["recipe"]);

            if (recipeId == 0)
            {
                NotFound();
            }

            List<Brewing> brewing = await  _context.Brewings.Include(b => b.Stage).Where(b => b.RecipeId == recipeId).ToListAsync();

            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            
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
