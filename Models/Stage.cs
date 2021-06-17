using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Stage
    {
        public Stage()
        {
            Temperatures = new HashSet<Temperature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Minutes { get; set; }
        public int? OptimalTemperature { get; set; }

        public virtual ICollection<Temperature> Temperatures { get; set; }
    }
}
