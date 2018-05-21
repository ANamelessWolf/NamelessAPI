using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Yuffie
{
    /// <summary>
    /// This class extends the utility to format, fix, concatenate a string
    /// </summary>
    public static partial class YuffieUtils
    {
        /// <summary>
        /// Removes the specified chars to be removed.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="charsToBeRemoved">The chars to be removed.</param>
        /// <returns>The string without the <see cref="charsToBeRemoved"/>.</returns>
        public static String Remove(this String str, params Char[] charsToBeRemoved)
        {
            if (str.Length > 0)
                return new String(str.Where(ch => !charsToBeRemoved.Contains(ch)).ToArray());
            else
                return str;
        }
        /// <summary>
        /// Removes the white spaces.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The string without white spaces</returns>
        public static String RemoveWhiteSpaces(this String str)
        {
            return str.Replace(" ", "");
        }
        /// <summary>
        /// Reverses the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The string in reveres order</returns>
        public static String Reverse(this String str)
        {
            if (str.Length > 0)
                return new String(str.OrderByDescending(ch => str.IndexOf(ch)).ToArray());
            else
                return str;
        }
        /// <summary>
        /// Get the Firtses sub string in quotation marks "".
        /// If the string doesn't had quotation marks, the string result is an empty string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The sub string in quotation marks.</returns>
        public static string FirtsInQuotation(this string str)
        {
            string word = "";
            if (str.Contains("\""))
            {
                int firstComma = str.IndexOf("\"") + 1;
                word = str.Substring(firstComma, str.Length - firstComma);
                int secondComma = word.IndexOf("\"");
                word = word.Substring(0, secondComma);
            }
            return word;
        }
        /// <summary>
        /// Filter the string allowing to pass just the characteres defined on the
        /// string filter
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="filter">The allowed characters on the filter</param>
        /// <returns>The string containing only the filter characters.</returns>
        public static string Filter(this string str, string filter)
        {
            return new String(str.Where(x => filter.Contains(x)).ToArray());
        }
    }
}
