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


        public async Task<IActionResult> Index() 
        {
            IEnumerable<WarmingHistory> histories = await _context.WarmingHistories.Include(history => history.Recipe).ToListAsync();

            return View(histories);
        }

        public async Task<IActionResult> Current(int recipeId)
        {
            List<Brewing> brewing = await _context.Brewings.Include(b => b.Stage).Where(b => b.RecipeId == recipeId).ToListAsync();

            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            
            if (recipe == null) 
            {
                NotFound();
            }

            beerOfThings.ViewModels.ProccessDetails proccess = new beerOfThings.ViewModels.ProccessDetails()
            {
                brewing = brewing
            };

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
            _context.WarmingHistories.Add(warming);
            await _context.SaveChangesAsync();
           
            return RedirectToAction("Current",warming.RecipeId);

        }
    }
}
