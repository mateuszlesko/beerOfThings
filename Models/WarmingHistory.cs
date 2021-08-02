using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class WarmingHistory
    {
        public WarmingHistory()
        {
            TemperatureProbes = new HashSet<TemperatureProbe>();
        }

        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public int? ProfileId { get; set; }
        public DateTime? WarmingDate { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<TemperatureProbe> TemperatureProbes { get; set; }
    }
}
