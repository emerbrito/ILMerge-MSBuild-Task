using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILMerge.MsBuild.Task
{
    static class StringExtensions
    {

        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNumeric(this string value)
        {
            float output;
            return float.TryParse(value, out output);
        }

    }
}
