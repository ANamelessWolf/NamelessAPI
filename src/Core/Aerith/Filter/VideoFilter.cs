using System;
using System.IO;
using System.Linq;

namespace Nameless.Libraries.Yggdrasil.Aerith.Filter
{
    /// <summary>
    /// This class creates a Video Filter
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Aerith.AerithFilter" />
    public class VideoFilter : AerithFilter
    {
        /// <summary>
        /// The video filter valid extensions
        /// </summary>
        public String[] Extensions
        {
            get
            {
                return new string[] { "MKV", "MP4", "AVI" };
            }
        }
        /// <summary>
        /// Check if the directory has at least one image file
        /// </summary>
        /// <param name="directory">The image directory</param>
        /// <returns>True if the directory has images</returns>
        public override bool IsDirectoryValid(DirectoryInfo directory)
        {
            return directory.GetFiles().Count(x => IsFileValid(x)) > 0;
        }
        /// <summary>
        /// Check if the file is an image
        /// </summary>
        /// <param name="file">The file to validate</param>
        /// <returns>true id the file is valid</returns>
        public override bool IsFileValid(FileInfo file)
        {
            return this.Extensions.Contains(file.Extension.ToLower());
        }
    }
}