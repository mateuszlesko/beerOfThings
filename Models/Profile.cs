using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Profile
    {
        public Profile()
        {
            WarmingHistories = new HashSet<WarmingHistory>();
        }

        public int Id { get; set; }
        public string Nick { get; set; }
        public string Occupation { get; set; }
        public string Token { get; set; }
        public int? PasswordId { get; set; }

        public virtual Password Password { get; set; }
        public virtual ICollection<WarmingHistory> WarmingHistories { get; set; }
    }
}
