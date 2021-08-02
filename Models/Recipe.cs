using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Brewings = new HashSet<Brewing>();
            IngredientsLists = new HashSet<IngredientsList>();
            WarmingHistories = new HashSet<WarmingHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Brewing> Brewings { get; set; }
        public virtual ICollection<IngredientsList> IngredientsLists { get; set; }
        public virtual ICollection<WarmingHistory> WarmingHistories { get; set; }
    }
}
