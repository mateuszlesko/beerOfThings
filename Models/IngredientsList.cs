using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class IngredientsList
    {
        public int? RecipeId { get; set; }
        public int? IngredientId { get; set; }
        public double? Amount { get; set; }
        public string Entity { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
