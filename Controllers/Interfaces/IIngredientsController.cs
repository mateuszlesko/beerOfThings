using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using beerOfThings.Models;

namespace beerOfThings.Controllers.Interfaces
{
    interface IIngredientsController
    {
        public Task<IActionResult> Index();
        public Task<IActionResult> Details(int? id);
        public IActionResult Create();
        public Task<IActionResult> Create([Bind("Id,Name")] Ingredient ingredient);
        public Task<IActionResult> Edit(int? id);
        public Task<IActionResult> Edit(int id, [Bind("Id,Name")] Ingredient ingredient);
        public Task<IActionResult> Delete(int? id);
        public Task<IActionResult> DeleteConfirmed(int id);
    }
}
