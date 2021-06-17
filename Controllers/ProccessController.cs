using Microsoft.AspNetCore.Mvc;
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
    public class ProccessController : Controller
    {
        beerOfThingsContext _context;

        public ProccessController(beerOfThingsContext context) 
        {
            _context = context;
        }


        public async Task<IActionResult> History() 
        {
            List<WarmingHistory> histories = await _context.WarmingHistories.Include(history => history.Recipe).ToListAsync();

            return View(histories);
        }

        public IActionResult Index(beerOfThings.ViewModels.ProccessDetails proccess)
        {
            if (ViewData["currentProccess"] == null) 
            {
                RedirectToAction("Create");
            }


            return View(proccess);
        }

        public async Task<ActionResult> Create() 
        {
            ViewBag.Recipes = await _context.Recipes.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("RecipeId")] WarmingHistory warming) 
        {
            _context.Add(warming);
            List<Brewing> brewing = await _context.Brewings.Include(b => b.Stage).Where(b => b.RecipeId == warming.RecipeId).ToListAsync();
            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == warming.RecipeId);

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddHours(8));

            HttpContext.Response.Cookies.Append("currentRecipe", recipe.Id.ToString(),cookieOptions);
            HttpContext.Response.Cookies.Append("currentStage", brewing[0].StageId.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("lastStage", brewing[brewing.Count - 1].StageId.ToString(), cookieOptions);

            beerOfThings.ViewModels.ProccessDetails proccess = new beerOfThings.ViewModels.ProccessDetails()
            {
                recipe = recipe,
                brewing = brewing
            };

            return RedirectToAction("Index",proccess);

        }
    }
}
