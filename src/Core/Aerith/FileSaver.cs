using Microsoft.Win32;
using Nameless.Libraries.Yggdrasil.Exceptions;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.IO;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class creates a new save dialog.
    /// </summary>
    /// <typeparam name="input">The type of parameters received by the save delegate</typeparam>
    public class FileSaver<input> : NamelessObject
    {
        #region Propiedades
        /// <summary>
        /// Gets or sets the start directory.
        /// </summary>
        /// <value>
        /// The start directory.
        /// </value>
        public String StartDirectory { get; set; }
        /// <summary>
        /// Gets the name of the saved file.
        /// </summary>
        /// <value>
        /// The name of the saved file.
        /// </value>
        public String SavedFileName { get { return savedFilePath; } }
        /// <summary>
        /// Gets or sets the saving title.
        /// </summary>
        /// <value>
        /// The saving title.
        /// </value>
        public String SavingTitle { get; set; }
        /// <summary>
        /// Allowed Extensions, write the extension name without the dot.
        /// </summary>
        public string[] AllowedExtensions;
        #endregion
        #region Variables
        /// <summary>
        /// The saved file path
        /// </summary>
        string savedFilePath;
        /// <summary>
        /// Defines the saving action
        /// </summary>
        /// <param name="filename">The name of the file to save.</param>
        /// <param name="savingParameters">The saving input parameters.</param>
        public delegate void SaveHandler(string filename, params input[] savingParameters);
        /// <summary>
        /// The action for saving the file.
        /// </summary>
        SaveHandler SaveAction;
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new saver object.
        /// </summary>
        /// <param name="action">The action for the saving transaction</param>
        /// <param name="allowedExtensions">The allowed extensions, write without the dot</param>
        public FileSaver(SaveHandler action, params string[] allowedExtensions)
        {
            string vals = String.Empty;
            foreach (string ext in allowedExtensions)
                vals += ext + ", ";
            vals = vals.Substring(0, vals.Length - 2);
            this.AllowedExtensions = allowedExtensions;
            this.SaveAction = action;
        }
        #endregion
        #region Actions
        /// <summary>
        /// Shows the save file dialog.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="saveTitle">The save dialog title.</param>
        /// <param name="savingParameters">The saving parameters.</param>
        /// <exception cref="BlackMateriaException"> Throws an exception if an error ocurred saving the file.</exception>
        public void ShowDialog(string categoryName, string saveTitle, params input[] savingParameters)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = AerithUtils.CreateFilter(this.AllowedExtensions, categoryName);
                saveDialog.Title = saveTitle;
                if (this.StartDirectory != String.Empty)
                {
                    if (Directory.Exists(this.StartDirectory))
                    {
                        DirectoryInfo dir = new DirectoryInfo(this.StartDirectory);
                        saveDialog.InitialDirectory = dir.FullName;
                    }
                    else
                        throw new BlackMateriaException(String.Format(ERR_DIR_MISSING, this.StartDirectory));
                }
                if (saveDialog.ShowDialog().Value && saveDialog.FileName != String.Empty)
                {
                    this.SaveAction(saveDialog.FileName, savingParameters);
                    this.savedFilePath = saveDialog.FileName;
                }
            }
            catch (System.Exception exc)
            {
                throw exc.CreateNamelessException<BlackMateriaException>(ERR_SAVING_FILE, this.savedFilePath != null ? this.savedFilePath : String.Empty);
            }
        }
        #endregion
    }
}
