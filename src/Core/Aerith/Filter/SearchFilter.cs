using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Aerith.Filter
{
    /// <summary>
    /// This class creates a search filter. A filter that can be used by the Aerith Scanner.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Aerith.AerithFilter" />
    public class SearchFilter : AerithFilter
    {
        #region Date Rules
        /// <summary>
        /// Sets or Get the a date rule for files created before this date.
        /// </summary>
        public DateTime CreatedBefore;
        /// <summary>
        /// Sets or Get the a date rule for files created after this date.
        /// </summary>
        public DateTime CreatedAfter;
        /// <summary>
        /// Sets or Get the a date rule for files last access before this date.
        /// </summary>
        public DateTime LastAccessAfter;
        /// <summary>
        /// Sets or Get the a date rule for files last access after this date.
        /// </summary>
        public DateTime LastAccessBefore;
        /// <summary>
        /// Sets or Get the a date rule for files last written before this date.
        /// </summary>
        public DateTime LastWriteBefore;
        /// <summary>
        /// Sets or Get the a date rule for files last written after this date.
        /// </summary>
        public DateTime LastWriteAfter;
        #endregion
        #region Size Rules
        /// <summary>
        /// Sets or Get the a size rule for files greater than this size.
        /// </summary>
        public AerithSize FileSizeGreaterThan;
        /// <summary>
        /// Sets or Get the a size rule for files lower than this size.
        /// </summary>
        public AerithSize FileSizeLowerThan;
        #endregion
        #region NameProperties
        /// <summary>
        /// Defines how the parent name is validated. Applies for file validation and directory validation
        /// </summary>
        public Func<DirectoryInfo, Boolean> ParentIsLike;
        /// <summary>
        /// Defines how the file name is validated. 
        /// </summary>
        public Func<FileInfo, Boolean> FileIsLike;
        /// <summary>
        /// Defines how the directory name is validated. 
        /// </summary>
        public Func<DirectoryInfo, Boolean> DirectoryIsLike;
        #endregion
        #region Extensions Properties
        /// <summary>
        /// Define a group of extensions that are valid in the file
        /// The '.' character is not needed to define the extension
        /// Its not case sensitive
        /// </summary>
        public String[] AllowedExtensions;
        #endregion    
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFilter"/> class.
        /// </summary>
        public SearchFilter()
        {
            this.CreatedAfter = DateTime.MinValue;
            this.LastAccessAfter = DateTime.MinValue;
            this.LastWriteAfter = DateTime.MinValue;
            this.CreatedBefore = DateTime.MaxValue;
            this.LastAccessBefore = DateTime.MaxValue;
            this.LastWriteBefore = DateTime.MaxValue;
            this.FileSizeLowerThan = new AerithSize(long.MaxValue);
            this.FileSizeGreaterThan = new AerithSize(0);
            this.AllowedExtensions = new String[0];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFilter"/> class.
        /// </summary>
        /// <param name="allowedExtensions">The filter allowed extensions.</param>
        public SearchFilter(params String[] allowedExtensions)
            : this()
        {
            this.AllowedExtensions = allowedExtensions;
        }
        /// <summary>
        /// Validates if the file is valid in the current filter
        /// </summary>
        /// <param name="file">The file to validate</param>
        /// <returns>True if the file is allowed in the filter</returns>
        public override bool IsFileValid(FileInfo file)
        {
            Boolean dateRule =
                file.CreationTime <= this.CreatedBefore && file.CreationTime >= this.CreatedAfter &&
                file.LastAccessTime <= this.LastAccessBefore && file.LastAccessTime >= this.LastAccessAfter &&
                file.LastWriteTime <= this.LastWriteBefore && file.LastWriteTime >= this.LastWriteAfter,
                sizeRule = file.Length <= FileSizeLowerThan.Length && file.Length >= FileSizeGreaterThan.Length,
                validExtensions = this.AllowedExtensions.Length == 0 ? true : this.AllowedExtensions.Select<String, String>(x => x.ToUpper()).Contains(file.Extension.Replace(".", "").ToUpper()),
                infoValidation = true;
            if (ParentIsLike != null)
                infoValidation = infoValidation && ParentIsLike(file.Directory);
            if (FileIsLike != null)
                infoValidation = infoValidation && FileIsLike(file);
            return dateRule && sizeRule && validExtensions && infoValidation;
        }
        /// <summary>
        /// Validates if the directory is valid
        /// </summary>
        /// <param name="directory">The directory to validate</param>
        /// <returns>True if the directory is allowed in the filter</returns>
        public override bool IsDirectoryValid(DirectoryInfo directory)
        {
            Boolean dateRule =
                directory.CreationTime <= this.CreatedBefore && directory.CreationTime >= this.CreatedAfter &&
                directory.LastAccessTime <= this.LastAccessBefore && directory.LastAccessTime >= this.LastAccessAfter &&
                directory.LastWriteTime <= this.LastWriteBefore && directory.LastWriteTime >= this.LastWriteAfter,
                infoValidation = true;
            if (ParentIsLike != null)
                infoValidation = infoValidation && ParentIsLike(directory.Parent);
            if (DirectoryIsLike != null)
                infoValidation = infoValidation && DirectoryIsLike(directory);
            return dateRule && infoValidation;
        }
    }
}