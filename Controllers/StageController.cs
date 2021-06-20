using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;
using beerOfThings.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace beerOfThings.Controllers
{
    public class StageController : Controller
    {
        private readonly beerOfThingsContext _context;
        public StageController(beerOfThingsContext context) 
        {
            _context = context;
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
