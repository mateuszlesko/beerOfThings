using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.Entities
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
    }
}
