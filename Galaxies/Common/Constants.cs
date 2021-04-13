using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Common
{
    public class Constants
    {
        public const string CommandSuffix = "Command";

        public const string SupportsLifeTrueValue = "yes";

        public const string SupportsLifeFalseValue = "no";

        public class EntityTypes
        {
            public const string Galaxy = "galaxy";
            public const string Star = "star";
            public const string Planet = "planet";
            public const string Moon = "moon";
        }

        public class EntityTypesPlural
        {
            public const string Galaxies = "galaxies";
            public const string Stars = "stars";
            public const string Planets = "planets";
            public const string Moons = "moons";
        }
    }
}
