using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Minutes { get; set; }
        public int? OptimalTemperatureId { get; set; }

        public virtual OptimalTemperature OptimalTemperature { get; set; }
    }
}
