using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using beerOfThings.ViewModels;
using beerOfThings.Models;

namespace beerOfThings.Controllers.Interfaces
{
    interface IStageController
    {
        public Task<IActionResult> Create();
        public Task<IActionResult> Create([Bind("StageName,Minutes,Temperature")] StageCreationVM stageCreationVM);
        public Task<IActionResult> Edit(int? id);
        public IActionResult Edit(int id, [Bind("Id,Name,Minutes,OptimalTemperature")] Stage stage);
    }
}
