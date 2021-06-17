using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Brewing
    {
        public int? StageId { get; set; }
        public int? RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
