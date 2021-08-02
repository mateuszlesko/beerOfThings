using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class TemperatureProbe
    {
        public int Id { get; set; }
        public double ValueC { get; set; }
        public DateTime ProbeTime { get; set; }
        public int WarmingId { get; set; }
        public int RecipeId { get; set; }
        public int StageId { get; set; }

        public virtual Stage Stage { get; set; }
        public virtual WarmingHistory Warming { get; set; }
    }
}
