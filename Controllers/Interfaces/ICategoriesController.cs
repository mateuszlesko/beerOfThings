using beerOfThings.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.Controllers.Interfaces
{
    interface ICategoriesController
    {
        public Task<IActionResult> Index();
        public Task<IActionResult> Details(int? id);
        public Task<IActionResult> Create([Bind("Id,Name")] Category category);
        public Task<IActionResult> Edit(int? id);
        public Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category);
        public Task<IActionResult> Delete(int? id);
        public Task<IActionResult> DeleteConfirmed(int id);
    }
}
