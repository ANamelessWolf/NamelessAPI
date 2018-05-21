using System;
using System.Text;

namespace Nameless.Libraries.Yggdrasil.Yuffie
{
    /// <summary>
    /// This class extends the utility to format, fix, concatenate a string
    /// </summary>
    public static partial class YuffieUtils
    {
        /// <summary>
        /// Turns a char array into a string. The chars are concatenate in ascending order.
        /// Between each character a needle is inserted.
        /// </summary>
        /// <param name="needle">The character inserted between characters</param>
        /// <param name="chars">The chars to be concatenate</param>
        /// <returns>The string result</returns>
        public static string Concat(this char[] chars, char needle)
        {
            StringBuilder sB = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                sB.Append(chars[0]);
                if (i < chars.Length - 1)
                    sB.Append(needle);
            }
            return sB.ToString();
        }
        /// <summary>
        /// Concats all items of an array in to a string.
        /// </summary>
        /// <param name="array">The array to concatenate.</param>
        /// <returns>The concatenated string</returns>
        public static string Concat(this string[] array)
        {
            StringBuilder sB = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                sB.Append(array[i]);
            return sB.ToString();
        }
        /// <summary>
        /// Turns a string array into a string. The strings are concatenate in ascending order.
        /// Between each string a needle is inserted.
        /// </summary>
        /// <param name="needle">The character inserted between characters</param>
        /// <param name="chars">The chars to be concatenate</param>
        /// <returns>The string result</returns>
        public static string Concat(this String[] collection, char ch)
        {
            if (collection.Length == 0)
                return String.Empty;
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (String s in collection)
                    sb.Append(String.Format("{0}{1}", s, ch));

                return sb.ToString().Substring(0, sb.ToString().Length - 1);
            }
        }
        /// <summary>
        /// Add a prefix enumeration to the string
        /// The enumeration is formatted in alphabetical order, adding padding zeros to the left
        /// </summary>
        /// <param name="str">The string to add the prefix</param>
        /// <param name="index">The index to be added</param>
        /// <param name="size">The number of zeros to use in the padding</param>
        /// <param name="addWhiteSpace">Adds a white space after the r if true</param>
        /// <returns>The string result</returns>
        public static string AddPrefixEnum(this String str, int index, int size, bool addWhiteSpace = true)
        {
            return String.Format("{0}{1}{2}", index.AddZeroPadding((int)Math.Pow(10, size)), addWhiteSpace ? " " : "", str);
        }
    }
}
