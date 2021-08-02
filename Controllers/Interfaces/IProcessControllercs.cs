using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;

namespace beerOfThings.Controllers.Interfaces
{
    interface IProcessControllercs
    {
        public Task<IActionResult> Index();
        public Task<IActionResult> Current();
        public Task<IActionResult> Create();
        public Task<IActionResult> Create([Bind("RecipeId")] WarmingHistory warming);
        public IActionResult Next();
        public IActionResult Previous();
    }
}
