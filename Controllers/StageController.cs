using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using beerOfThings.ViewModels;
using beerOfThings.Models;
using beerOfThings.Helpers;

namespace beerOfThings.Controllers
{
    public class StageController : Controller
    {
        private readonly BeerOfThingsContext _context;
        public StageController(BeerOfThingsContext context) 
        {
            _context = context;
        }

        public IActionResult MoveNext()
        {

            return View();
        }

        public async Task<IActionResult> Create() 
        {
            StageCreationVM creationVM = new StageCreationVM();
            int recipeId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "CreatedRecipeId");
            Recipe recipe = await _context.Recipes.Where(_recipe => _recipe.Id == recipeId).FirstOrDefaultAsync();
            creationVM.setRecipeName(recipe.Name); 
            return View(creationVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("StageName,Minutes,Temperature")] StageCreationVM stageCreationVM) 
        {

            int recipeId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "CreatedRecipeId");
            if(recipeId == 0)
            {
                return RedirectToAction("Error");
            }

            Stage stage = new Stage();
            stage.Name = stageCreationVM.StageName;
            stage.Minutes = stageCreationVM.Minutes;
            stage.OptimalTemperature = stageCreationVM.Temperature;
            
            _context.Add(stage);

            Recipe recipe = await _context.Recipes.Where(r => r.Id == recipeId).FirstOrDefaultAsync();
            
            Brewing brewing = new Brewing();

            brewing.Recipe = recipe;
            brewing.RecipeId = recipeId;
            brewing.Stage = stage;
            brewing.StageId = stage.Id;

            _context.Add(brewing);

            await _context.SaveChangesAsync();

            return RedirectToAction("MoveNext");
        }

       

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stage stage = await _context.Stages.FirstOrDefaultAsync( s => s.Id == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Minutes,OptimalTemperature")] Stage stage)
        {
            if (id != stage.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(stage);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StageExists(stage.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return View(stage);
        }

        private bool StageExists(int id)
        {
            return _context.Stages.Any(e => e.Id == id);
        }
    }
}
