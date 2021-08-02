using beerOfThings.Models;
using beerOfThings.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.Controllers.Interfaces
{
    interface IRecipeController
    {
        public Task<ActionResult> Index([Bind("category")] int? category);
        public Task<ActionResult> Details(int? id);
        public Task<IActionResult> Create();
        public Task<IActionResult> AddIngredientToRecipe();
        public Task<IActionResult> AddIngredientToRecipe([Bind("IngredientId,Amount,Entity")] RecipeIngredientVM ingredientVM);
        public IActionResult Create([Bind("Name,CategoryId")] RecipeCreationVM creationVM);
        public IActionResult MoveToRecipeStage(Recipe recipe);
    }
}
