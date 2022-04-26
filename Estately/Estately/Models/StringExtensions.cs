using System;
using System.Collections.Generic;
using System.Text;

namespace Estately.Models
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison stringComparison)
        {
            return source?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
