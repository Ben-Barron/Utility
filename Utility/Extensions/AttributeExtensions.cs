using System;
using System.Linq;

namespace Utility.Extensions
{
    public static class AttributeExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        }
    }
}
