using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class WarmingHistory
    {
        public WarmingHistory()
        {
            Temperatures = new HashSet<Temperature>();
        }

        public int Id { get; set; }
        public int? RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<Temperature> Temperatures { get; set; }
    }
}
