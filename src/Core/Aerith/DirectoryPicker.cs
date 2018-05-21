using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Windows.Forms;
using static System.Environment;

namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class creates a dialog to pick a directory
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class DirectoryPicker : NamelessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryPicker"/> class.
        /// </summary>
        public DirectoryPicker()
        {
        }
        /// <summary>
        /// The initial directory
        /// </summary>
        public SpecialFolder InitialDirectory;
        /// <summary>
        /// Creates a Folder browser dialog to pick a path.
        /// </summary>
        /// <param name="dialogDescription">The dialog description.</param>
        /// <param name="selPath">As an output parameter the directory path.</param>
        /// <returns>True if the directory is selected</returns>
        public Boolean PickPath(String dialogDescription, out String selPath)
        {
            Boolean flag;
            FolderBrowserDialog oDialog = new FolderBrowserDialog();
            selPath = String.Empty;
            oDialog.Description = dialogDescription;
            oDialog.RootFolder = InitialDirectory;
            flag = oDialog.ShowDialog() == DialogResult.OK;
            if (flag)
                selPath = oDialog.SelectedPath;
            return flag;
        }
    }
}
