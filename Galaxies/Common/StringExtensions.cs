using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Common
{
    public static class StringExtensions
    {
        public static string TrimBrackets(this string name)
        {
            return name.Trim('[', ']');
        }
    }
}
