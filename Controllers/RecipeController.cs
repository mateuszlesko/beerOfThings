using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using beerOfThings.Models;
using beerOfThings.ViewModels;
using beerOfThings.Helpers;
using beerOfThings.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace beerOfThings.Controllers
{
    public class RecipeController : Controller, IRecipeController
    {
        private readonly BeerOfThingsContext _context;

        public RecipeController(BeerOfThingsContext context)
        {
            _context = context;
        }


        public IActionResult Error()
        {
            return View();
        }

        public async Task<ActionResult> Index([Bind("category")] int? category)
        {

            List<Recipe> recipes = new List<Recipe>();
            if (category == null) 
            {
                recipes = await _context.Recipes.ToListAsync();
            }
            else
            {
                recipes = await _context.Recipes.Where(recipe => recipe.CategoryId == category).ToListAsync();
            }   
            List<Category> categories = await _context.Categories.ToListAsync();

            RecipeIndexVM indexVM = new RecipeIndexVM()
            {
                recipes = recipes,
                categories = categories
            };
            return View(indexVM);
        }

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("ZERO");
                return NotFound();
            }

            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            List<IngredientsList> ingredientsList = await _context.IngredientsLists.Include(Ingredient => Ingredient.Ingredient).Where(list => list.RecipeId == id).ToListAsync();
            List<Brewing> brewingList = await _context.Brewings.Include(Stage => Stage.Stage).Where(brewing => brewing.RecipeId == id).ToListAsync();



            RecipeFullDetailsViewModel recipeFullDetails = new RecipeFullDetailsViewModel()
            {
                recipe = recipe,
                ingredientsList = ingredientsList,
                brewingProccess = brewingList,
            };

            return View(recipeFullDetails);
        }

        //GET: Recipe/Create
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create()
        {
            RecipeCreationVM recipeCreation = new RecipeCreationVM();
            recipeCreation.SetCategories(await _context.Categories.ToListAsync());
            return View(recipeCreation);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Create([Bind("Name,CategoryId")] RecipeCreationVM creationVM ) 
        {
          
            Recipe recipe = new Recipe();
            recipe.CategoryId = creationVM.CategoryId;
            recipe.Category = _context.Categories.Where(category => category.Id == creationVM.CategoryId).FirstOrDefault();
            recipe.Name = creationVM.Name.Equals(null) ? "receptura bez nazwy" : creationVM.Name;
           
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            SessionHelper.SetObjectAsJson(HttpContext.Session, "CreatedRecipeId", recipe.Id);

            return RedirectToAction("AddIngredientToRecipe");
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddIngredientToRecipe() 
        {

            int recipeId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "CreatedRecipeId");

            if(recipeId == 0)
            {
               return RedirectToAction("Error");
            }

            RecipeIngredientVM ingredientVM = new RecipeIngredientVM();
            ingredientVM.SetIngredientsList(await _context.Ingredients.ToListAsync());
            ingredientVM.SetRecipeName((await _context.Recipes.Where(recipe => recipe.Id == recipeId).FirstOrDefaultAsync()).Name);

            return View(ingredientVM);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddIngredientToRecipe([Bind("IngredientId,Amount,Entity")] RecipeIngredientVM ingredientVM)
        {
            int recipeId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "CreatedRecipeId");
            if (recipeId == 0 || ingredientVM.IngredientId == 0)
            {
                return RedirectToAction("Error");
            }

            Recipe recipe = await _context.Recipes.Where(r => r.Id == recipeId).FirstOrDefaultAsync();
            Ingredient ingredient = await _context.Ingredients.Where(i => i.Id == ingredientVM.IngredientId).FirstOrDefaultAsync();

            IngredientsList ingredientsList = new IngredientsList();

            if(recipe.Equals(null) || ingredient.Equals(null))
            {
                return RedirectToAction("Error");
            }

            ingredientsList.Recipe = recipe;
            ingredientsList.RecipeId = recipeId;
            ingredientsList.IngredientId = ingredientVM.IngredientId;
            ingredientsList.Ingredient = ingredient;
            ingredientsList.Entity = ingredientVM.Entity;
            ingredientsList.Amount = ingredientVM.Amount;

            _context.Add(ingredientsList);

            _context.SaveChanges();

            return RedirectToAction("MoveToRecipeStage", recipe);
        }

        [Authorize(Policy = "Admin")]
        public IActionResult MoveToRecipeStage(Recipe recipe)
        {
            return View(recipe);
        }
    }
}
