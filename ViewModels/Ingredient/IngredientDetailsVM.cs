using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;

namespace beerOfThings.ViewModels
{
    public class IngredientDetailsVM
    {
        public Ingredient ingredient { get; set; }
        public List<Recipe> recipes = new List<Recipe>();
    }
}
