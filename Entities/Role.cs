using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beerOfThings.Entities
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Bearer = "Bearer";
        public const string User = "User";
        public const string AdminOrBearer = "Admin,Bearer";
    }
}
