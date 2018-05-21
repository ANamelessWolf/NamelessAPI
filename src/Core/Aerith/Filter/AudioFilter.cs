using System;
using System.IO;
using System.Linq;

namespace Nameless.Libraries.Yggdrasil.Aerith.Filter
{
    /// <summary>
    /// This class creates an Audio Filter
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Aerith.AerithFilter" />
    public class AudioFilter : AerithFilter
    {
        /// <summary>
        /// The audio filter valid extensions
        /// </summary>
        public String[] Extensions
        {
            get
            {
                return new string[] { "WAV", "AIFF", "AU", "PCM", "ALAC", "FLAC", "TTA", "ATRAC", "GP",
                                  "AMR", "IKLAX", "MPC", "MSV", "MXP4", "RA", "RM", "RAM", "VOX", "M3U",
                                  "PLS", "ACT", "AAC",  "AWB", "DSS", "DVF", "GSM", "IVS", "MP4", "MMF",
                                  "MP3", "OGG", "WMA", "M4A" };
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