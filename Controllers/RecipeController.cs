using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using beerOfThings.Models;
using beerOfThings.ViewModels;

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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("ZERO");
                return NotFound();
            }

            Recipe recipe = _context.Recipes.FirstOrDefault(recipe => recipe.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            List<IngredientsList> ingredientsList = _context.IngredientsLists.Include(Ingredient => Ingredient.Ingredient).Where(list => list.RecipeId == id).ToList();
            List<Brewing> brewingList = _context.Brewings.Include(Stage => Stage.Stage).Where(brewing => brewing.RecipeId == id).ToList();



            RecipeFullDetailsViewModel recipeFullDetails = new RecipeFullDetailsViewModel()
            {
                recipe = recipe,
                ingredientsList = ingredientsList,
                brewingProccess = brewingList,
            };

            return View(recipeFullDetails);
        }
    }
}
