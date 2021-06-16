using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;
using beerOfThings.ViewModels;

namespace beerOfThings.Controllers
{
    public class IngredientsListController : Controller
    {
        private readonly beerOfThingsContext _context;

        public IngredientsListController(beerOfThingsContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult> Edit(int? id, int? recipeId) 
        {

            int ingredientId = id ?? default(int);
            int recipe = recipeId ?? default(int);

            if (IngredientExists(ingredientId) && RecipeExists(recipe)) 
            {
                List<Ingredient> ingredients = await _context.Ingredients.ToListAsync();
                IngredientsList position = await _context.IngredientsLists.FirstOrDefaultAsync(l => l.IngredientId == ingredientId && l.RecipeId == recipe);

                EditIngredientsListViewModel editIngredients = new EditIngredientsListViewModel()
                {
                    ingredients = ingredients,
                    ingredientsLists = position
                };
                return View(editIngredients);
            }
            else
            {
                return NotFound();
            }
            
           
        }

        public IActionResult Index()
        {
            return View();
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
