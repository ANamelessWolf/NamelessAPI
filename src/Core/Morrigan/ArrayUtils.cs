using Nameless.Libraries.Yggdrasil.Lilith;
using System;
namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// This class create utility to manage the functionality of morrigan Aensaland
    /// data structures
    /// </summary>
    public static partial class AenslandUtils
    {
        /// <summary>
        /// Appends and array to another array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayToAppend">The array to append.</param>
        /// <returns>The appended array</returns>
        public static T[] Append<T>(this T[] array, T[] arrayToAppend) where T : class
        {
            T[] nArray = new T[array.Length + arrayToAppend.Length];
            int index;
            for (int i = 0; i < nArray.Length; i++)
            {
                index = i < array.Length ? i : (i - array.Length);
                nArray[i] = i < array.Length ? array[index] : arrayToAppend[index];
            }
            return nArray;
        }
        /// <summary>
        /// Appends and array to another array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayToAppend">The array to append.</param>
        /// <returns>The appended array</returns>
        public static T[] AppendStruct<T>(this T[] array, T[] arrayToAppend) where T : struct
        {
            T[] nArray = new T[array.Length + arrayToAppend.Length];
            int index;
            for (int i = 0; i < nArray.Length; i++)
            {
                index = i < array.Length ? i : (i - array.Length);
                nArray[i] = i < array.Length ? array[index] : arrayToAppend[index];
            }
            return nArray;
        }
        /// <summary>
        /// Appends and array to another array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayToAppend">The array to append.</param>
        /// <returns>The appended array</returns>
        public static String[][] Append(this String[][] array, String[][] arrayToAppend)
        {
            String[][] nArray = new string[array.Length + arrayToAppend.Length][];
            int index;
            for (int i = 0; i < nArray.Length; i++)
            {
                index = i < array.Length ? i : (i - array.Length);
                nArray[i] = i < array.Length ? array[index] : arrayToAppend[index];
            }
            return nArray;
        }
        /// <summary>
        /// Expands an array
        /// </summary>
        /// <typeparam name="T">The array type data</typeparam>
        /// <param name="array">The current array</param>
        /// <param name="expand">The size to expand the array</param>
        /// <returns>Expanded array</returns>
        public static T[] ExpandArray<T>(this T[] array, int expand = 1) where T : NamelessObject
        {
            T[] nArr = new T[array.Length + expand];
            for (int i = 0; i < array.Length; i++)
                nArr[i] = array[i];
            return nArr;
        }
    }
}
