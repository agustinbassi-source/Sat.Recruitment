using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sat.Recruitment.Common.Helpers
{
    public static class PropertyExtensions
    {
        public static string PropName<T, TProp>(this T o, Expression<Func<T, TProp>> propertySelector)
        {
            MemberExpression body = (MemberExpression)propertySelector.Body;
            return body.Member.Name;
        }
    }
}
