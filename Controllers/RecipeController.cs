using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using beerOfThings.Models;

namespace beerOfThings.Controllers
{
    public class RecipeController : Controller
    {
        private readonly beerOfThingsContext _context;

        public RecipeController(beerOfThingsContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            List<Recipe> recipes = await _context.Recipes.ToListAsync();
            return View(recipes);
        }
    }
}
