using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientsLists = new HashSet<IngredientsList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IngredientsList> IngredientsLists { get; set; }
    }
}
