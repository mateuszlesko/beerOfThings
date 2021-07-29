using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;

namespace beerOfThings.ViewModels
{
    public class RecipeIngredientVM
    {
        public int IngredientId { get; set; }
        public string Entity { get; set; }
        public float Amount { get; set; }
        private string _RecipeName;
        private int _RecipeId { get; set; }
        private List<Ingredient> _Ingredients;
        private static List<string> _entities = new List<string>() { "g","dag","kg"};
        
        public void SetIngredientsList(List<Ingredient> ingredients)
        {
            _Ingredients = ingredients;
        }

        public List<Ingredient> GetIngredientsList() => _Ingredients;

        public List<string> GetEntities() => _entities;
        
        public void SetRecipeName(string recipe)
        {
            _RecipeName = recipe;
        }

        public string GetRecipeName() => _RecipeName;
    }
}
