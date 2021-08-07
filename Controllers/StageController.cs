using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using beerOfThings.ViewModels;
using beerOfThings.Models;
using beerOfThings.Helpers;
using beerOfThings.Entities;
using beerOfThings.Controllers.Interfaces;

namespace beerOfThings.Controllers
{
    public class StageController : Controller, IStageController
    {
        private readonly BeerOfThingsContext _context;
        public StageController(BeerOfThingsContext context) 
        {
            _context = context;
        }

        [Authorize(Roles = Role.AdminOrBearer)]
        public IActionResult MoveNext()
        {

            return View();
        }

        [Authorize(Roles = Role.AdminOrBearer)]
        public async Task<IActionResult> Create() 
        {
            StageCreationVM creationVM = new StageCreationVM();
            int recipeId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "CreatedRecipeId");
            Recipe recipe = await _context.Recipes.Where(_recipe => _recipe.Id == recipeId).FirstOrDefaultAsync();
            creationVM.setRecipeName(recipe.Name); 
            return View(creationVM);
        }

        [HttpPost]
        [Authorize(Roles = Role.AdminOrBearer)]
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


        [Authorize(Roles = Role.AdminOrBearer)]
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
        [Authorize(Roles = Role.AdminOrBearer)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Minutes,OptimalTemperature")] Stage stage)
        {
            if (id != stage.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(stage);
                _context.SaveChanges();
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
