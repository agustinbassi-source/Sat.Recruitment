using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sat.Recruitment.Common.Helpers
{
    public static  class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> data)
        {
            if (data == null)
                return true;

            if (data.ToList().Count() == 0)
                return true;

            return false;
        }
    }
}
