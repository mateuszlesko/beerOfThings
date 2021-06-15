using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class OptimalTemperature
    {
        public OptimalTemperature()
        {
            Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public int? Value { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }
    }
}
