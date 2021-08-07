using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
