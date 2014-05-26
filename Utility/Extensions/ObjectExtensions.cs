using System;
using System.Diagnostics;
using System.Linq;

namespace Utility.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetPropertiesString(this object obj, bool singleLineFormatting = false)
        {
            var values = obj.GetType().GetProperties()
                .Where(p => p.CanRead)
                .Select(
                    p =>
                    {
                        try
                        {
                            return string.Format("{0} = '{1}'", p.Name, p.GetMethod.Invoke(obj, null));
                        }
                        catch
                        {
                            return string.Format("{0} = [Unable to get value!]", p.Name);
                        }
                    });

            return (singleLineFormatting)
                ? string.Format("[ {0} ]", string.Join(",", values))
                : string.Format(
                    "[" + Environment.NewLine + "\t{0}" + Environment.NewLine + "]",
                    string.Join(Environment.NewLine + "\t", values));
        }

        public static void PrintPropertiesString(this object obj, bool singleLine = false)
        {
            Debug.Print(GetPropertiesString(obj, singleLine));
        }
    }
}
