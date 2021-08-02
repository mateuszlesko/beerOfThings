using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.ViewModels
{
    public class StageCreationVM
    {
        private string RecipeName;
        public string StageName { get; set; }
        public int Minutes { get; set; }
        public int Temperature { get; set; }

        public string getRecipeName() => RecipeName;
        
        public void setRecipeName(string recipe)
        {
            RecipeName = recipe;
        }
    }
}
