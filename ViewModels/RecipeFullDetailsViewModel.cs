using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;

namespace beerOfThings.ViewModels
{
    public class RecipeFullDetailsViewModel
    {
        public Recipe recipe = new Recipe();
        public List<IngredientsList> ingredientsList = new List<IngredientsList>();
        public List<Brewing> brewingProccess = new List<Brewing>();
        public List<OptimalTemperature> optimalTemperatures = new List<OptimalTemperature>();  
    }
}
