using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    //Extension Methods : class Static olmalı ve içerisindeki method static olmalıdır ve değer verirken this kullanılmalıdır. Classın içerisind birden fazla method yazılabilir.
    internal static class ExtensionMethods
    {
        public static string GetFirstCharacter(this string input)
        {
            return input.Substring(0, 1);
        }

        public static string GetSeoUrl(this string text)
        {
            text = text.Replace(" ", "-").ToLower();
            text = text.Replace("ç", "c");
            return text;
        }

        public static string GetFullName(this Product product)
        {
            return $"{product.Id} - {product.Name}";
        }
    }
}
