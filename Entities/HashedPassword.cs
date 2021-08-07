using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.Entities
{
    public class HashedPassword
    {
        public string Hashed { get; set; }
        public string Salt { get; set; }
    }
}
