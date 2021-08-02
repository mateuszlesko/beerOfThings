using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Password
    {
        public Password()
        {
            Profiles = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
