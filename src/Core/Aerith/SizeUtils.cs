using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class extends the file management functionality of Aerith
    /// </summary>
    public static partial class AerithUtils
    {
        /// <summary>
        /// The size of one byte
        /// </summary>
        public const long B = 1;
        /// <summary>
        /// The size of one Kylobyte in bytes
        /// </summary>
        public const long KB = 1024;
        /// <summary>
        /// The size of one Megabyte in bytes
        /// </summary>
        public const long MB = 1048576;
        /// <summary>
        /// The size of one Gygabyte in bytes
        /// </summary>
        public const long GB = 1073741824;
        /// <summary>
        /// The size of one Terabyte in bytes
        /// </summary>
        public const long TB = 1099511627776;
        /// <summary>
        /// Creates a new human-readable size from a byte value
        /// </summary>
        /// <param name="size">The size in bytes</param>
        /// <returns>The Aerith size</returns>
        public static AerithSize GetSizeFromBytes(this long size)
        {
            return new AerithSize((long)size);
        }
        /// <summary>
        /// Creates a new human-readable size from a kilo byte value
        /// </summary>
        /// <param name="size">The size in kilo bytes</param>
        /// <returns>The Aerith size</returns>
        public static AerithSize GetSizeFromKiloBytes(this double size)
        {
            return new AerithSize((long)(size * KB));
        }
        /// <summary>
        /// Creates a new human-readable size from a mega byte value
        /// </summary>
        /// <param name="size">The size in mega bytes</param>
        /// <returns>The Aerith size</returns>
        public static AerithSize GetSizeFromMegaBytes(this double size)
        {
            return new AerithSize((long)(size * MB));
        }
        /// <summary>
        /// Creates a new human-readable size from a giga byte value
        /// </summary>
        /// <param name="size">The size in giga bytes</param>
        /// <returns>The Aerith size</returns>
        public static AerithSize GetSizeFromGigaBytes(this double size)
        {
            return new AerithSize((long)(size * GB));
        }
        /// <summary>
        /// Creates a new human-readable size from a tera byte value
        /// </summary>
        /// <param name="size">The size in giga bytes</param>
        /// <returns>The Aerith size</returns>
        public static AerithSize GetSizeFromTeraBytes(this double size)
        {
            return new AerithSize((long)(size * TB));
        }
    }
}
