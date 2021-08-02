using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Stage
    {
        public Stage()
        {
            Brewings = new HashSet<Brewing>();
            TemperatureProbes = new HashSet<TemperatureProbe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public int? OptimalTemperature { get; set; }

        public virtual ICollection<Brewing> Brewings { get; set; }
        public virtual ICollection<TemperatureProbe> TemperatureProbes { get; set; }
    }
}
