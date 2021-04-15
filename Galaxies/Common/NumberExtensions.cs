using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Common
{
    public static class NumberExtensions
    {
        public static bool IsInRange(this int num, int min, int max)
        {
            return num >= min && num <= max;
        }

        public static bool IsInRange(this double num, double min, double max)
        {
            return num >= min && num <= max;
        }
    }
}
