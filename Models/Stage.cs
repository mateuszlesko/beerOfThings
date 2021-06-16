﻿using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Stage
    {
        public Stage()
        {
            OptimalTemperatures = new HashSet<OptimalTemperature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Minutes { get; set; }
        public int? OptimalTemperatureId { get; set; }

        public virtual OptimalTemperature OptimalTemperature { get; set; }
        public virtual ICollection<OptimalTemperature> OptimalTemperatures { get; set; }
    }
}