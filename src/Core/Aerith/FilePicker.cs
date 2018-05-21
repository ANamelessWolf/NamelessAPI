using Microsoft.Win32;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.IO;

namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class creates a dialog to pick a file
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class FilePicker : NamelessObject
    {
        /// <summary>
        /// True if the file picker allows multiple selection
        /// </summary>
        public Boolean AllowMultipleSelection;
        /// <summary>
        /// Get or sets the list of file extensions allowed by the file picker
        /// </summary>
        public String[] ExtensionFilter;
        /// <summary>
        /// Initializes a new instance of the <see cref="FilePicker"/> class.
        /// </summary>
        /// <param name="allowMultipleSelection">if set to <c>true</c> [allow multiple selection].</param>
        /// <param name="allowedExtensions">The allowed extensions.</param>
        public FilePicker(bool allowMultipleSelection, params string[] allowedExtensions)
        {
            this.AllowMultipleSelection = allowMultipleSelection;
            this.ExtensionFilter = allowedExtensions;
        }
        /// <summary>
        /// The initial directory
        /// </summary>
        public string InitialDirectory;
        /// <summary>
        /// Gets the file path from the windows open file dialog
        /// </summary>
        /// <param name="catName">The file type category</param>
        /// <param name="fileDialogTitle">The file dialog title</param>
        /// <returns>The path of the selected file, empty if the selection is cancelled</returns>
        public Boolean PickPath(String catName, String fileDialogTitle, out String selPath)
        {
            Boolean flag;
            OpenFileDialog oDialog = new OpenFileDialog();
            selPath = String.Empty;
            oDialog.Filter = AerithUtils.CreateFilter(ExtensionFilter, catName);
            oDialog.Title = fileDialogTitle;
            oDialog.Multiselect = this.AllowMultipleSelection;
            if (InitialDirectory != null && Directory.Exists(InitialDirectory))
                oDialog.InitialDirectory = InitialDirectory;
            flag = oDialog.ShowDialog().Value;
            if (flag)
                selPath = oDialog.FileName;
            return flag;
        }
    }
}