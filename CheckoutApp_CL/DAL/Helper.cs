using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp_CL.DAL
{
    internal static class Helper
    {
        public static string GetColumnNames(this Type type, string alias = null, HashSet<string> excludedProp = null)
        {
            var props = type.GetProperties();
            var cols = new List<string>();

            foreach (var prop in props)
            {
                if (prop.CustomAttributes.Any(z => z.AttributeType == typeof(IgnoreMappingAttribute)))
                    continue;
                if (alias != null)
                    cols.Add($"{alias}.{prop.Name}");
                else
                    cols.Add($"{prop.Name}");
            }

            return string.Join(" ,", cols);
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class IgnoreMappingAttribute : Attribute { }
}
