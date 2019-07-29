using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnyAndMyAll
{
    public static class IntExtensions
    {
        public static bool MyAll(this int[] arr, Func<int, bool> predicate)
        {
            foreach (var i in arr)
            {
                if (!predicate(i))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool MyAny(this int[] arr, Func<int, bool> predicate)
        {
            foreach (var i in arr)
            {
                if (predicate(i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
