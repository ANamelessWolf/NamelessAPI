﻿using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class extends the file management functionality of Aerith
    /// </summary>
    public static partial class AerithUtils
    {
        /// <summary>
        /// Creates a file filter
        /// </summary>
        /// <param name="catName">The name of the filter category</param>
        /// <returns>The filter rule as a string</returns>
        public static string CreateFilter(string[] extFilter, String catName)
        {
            StringBuilder filter = new StringBuilder();
            filter.Append(catName);
            filter.Append(" (");
            for (int i = 0; i < extFilter.Length; i++)
            {
                filter.Append("*.");
                filter.Append(extFilter[i].ToUpper());
                if (i < extFilter.Length - 1)
                    filter.Append(";");
            }
            filter.Append(")|");
            for (int i = 0; i < extFilter.Length; i++)
            {
                filter.Append("*.");
                filter.Append(extFilter[i].ToUpper());
                if (i < extFilter.Length - 1)
                    filter.Append(";");
            }
            return filter.ToString();
        }
        /// <summary>
        /// Reads the fully a stream and creates a byte array
        /// </summary>
        /// <param name="input">The input stream to read</param>
        /// <returns>The file data array</returns>
        public static byte[] CreateByteArray(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Gets the directory path, for a class of the running assembly
        /// </summary>
        /// <param name="type">The type to get the assembly path</param>
        /// <returns>The path of the running assembly</returns>
        public static String GetPath(this Type type)
        {
            FileInfo file = new FileInfo(Assembly.GetAssembly(type).GetName().FullName);
            return file.Directory.FullName;
        }
        /// <summary>
        /// Creates a scanner from the specified directory path.
        /// </summary>
        /// <param name="startDirectory">The scanner starting directory.</param>
        /// <param name="deepSearch">if set to <c>true</c> [enables scanner deep search].</param>
        /// <param name="omitErrors">if set to <c>true</c> [enable scanner to omit errors].</param>
        /// <returns>The Aerith Scanner</returns>
        public static AerithScanner Scan(this string startDirectory, Boolean deepSearch = false, Boolean omitErrors = false)
        {
            return new AerithScanner(startDirectory, deepSearch, omitErrors);
        }
        /// <summary>
        /// Creates the file from path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        public static void CreateFileFromPath(this string filePath, Boolean replace = false)
        {
            //Checamos si existe el archivo
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            else if (replace)
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }
        }

    }
}