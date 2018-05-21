using Nameless.Libraries.Yggdrasil.Lilith;
using static Nameless.Libraries.Yggdrasil.Assets.CommonStrings;
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
        /// Gets the invalid XML node characters.
        /// </summary>
        /// <value>
        /// The invalid XML node characters.
        /// </value>
        public static Char[] InvalidXmlNodeCharacters { get { return INVALID_XML_CH.ToCharArray(); } }
        /// <summary>
        /// Remove unsopported characters for a xml node name
        /// </summary>
        /// <returns>A valid xml name.</returns>
        public static String ToXmlName(this String str)
        {
            return str.RemoveWhiteSpaces().Remove(InvalidXmlNodeCharacters);
        }
        /// <summary>
        /// Truncates the specified length.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The length.</param>
        /// <returns>The formatted string</returns>
        public static string Truncate(this string str, int length)
        {
            if (str.Length > length)
                str = str.Substring(0, length);
            return str;
        }
        /// <summary>
        /// Get a substring of size <see cref="length"/> and add ellipsis mark.
        /// The last three characters are always "..."
        /// </summary>
        /// <param name="str">The string to put in ellipsis mark</param>
        /// <param name="length">The string size</param>
        /// <returns>The formatted string</returns>
        public static String ToEllipsisSentence(this String str, int length)
        {
            if (str.Length > length - 3)
                return String.Format("{0}...", str.Substring(0, length - 3));
            else if (str.Length > 3)
                return String.Format("{0}...", str.Substring(0, str.Length - 3));
            else
                return "...";
        }
        /// <summary>
        /// Put a number in string with zero padding based on a max number.
        /// Example
        /// max = 100, format 000, Numeber 1, formatted 001
        /// max = 30000, format 00000, Numeber 1, formatted 00001
        /// </summary>
        /// <param name="number">The number to be formatted.</param>
        /// <param name="maxNumber">The count of numbers to be renamed</param>
        /// <returns>The number with zero padding.</returns>
        public static string AddZeroPadding(this int number, int maxNumber)
        {
            String zeros = String.Empty,
                   numStr = number.ToString();
            while (zeros.Length != maxNumber.ToString().Length)
                zeros += "0";
            return String.Format("{0:" + zeros + "}", number);
        }
        /// <summary>
        /// Extracts a line from wiki style line.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The found line</returns>
        public static String ExtractLineFromWikiStyle(this string str)
        {
            if (str[0].IsInt())
                return str.FirtsInQuotation();
            else
                return String.Empty;
        }
    }
}
