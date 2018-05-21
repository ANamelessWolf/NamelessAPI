using Nameless.Libraries.Yggdrasil.Aerith.Filter;
using Nameless.Libraries.Yggdrasil.Exceptions;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.IO;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class creates a file and directory scanner. The scanner needs a start directory and defined the
    /// type of search.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class AerithScanner : NamelessObject
    {
        /// <summary>
        /// Handles the action when the scanner found a file
        /// </summary>
        /// <param name="input">The scanner input.</param>
        /// <param name="startDirectory">The scanner start directory.</param>
        /// <param name="currentFile">The current file found by the scanner.</param>
        public delegate void FileScannerHandler(ref Object input, DirectoryInfo startDirectory, FileInfo currentFile);
        /// <summary>
        /// Handles the action when the scanner found a directory
        /// </summary>
        /// <param name="input">The scanner input.</param>
        /// <param name="startDirectory">The scanner start directory.</param>
        /// <param name="currentDirectory">The current directory found by the scanner.</param>
        public delegate void DirectoryScannerHandler(ref Object input, DirectoryInfo startDirectory, DirectoryInfo currentDirectory);
        /// <summary>
        /// Gets the found files by the scanner.
        /// </summary>
        /// <value>
        /// The files found files by the scanner.
        /// </value>
        public FileInfo[] Files { get { return _Files != null ? _Files : new FileInfo[0]; } }
        /// <summary>
        /// The files found by the scanner.
        /// </summary>
        FileInfo[] _Files;
        /// <summary>
        /// Gets the found directories by the scanner.
        /// </summary>
        /// <value>
        /// The files found directories by the scanner.
        /// </value>
        public DirectoryInfo[] Directories { get { return _Directories != null ? _Directories : new DirectoryInfo[0]; } }
        /// <summary>
        /// The directories found by the scanner.
        /// </summary>
        DirectoryInfo[] _Directories;
        /// <summary>
        /// Gets the number of found files.
        /// </summary>
        /// <value>
        /// The file count.
        /// </value>
        public int FileCount { get { return Files.Length; } }
        /// <summary>
        /// Gets the number of found directories.
        /// </summary>
        /// <value>
        /// The directory count.
        /// </value>
        public int DirectoryCount { get { return Files.Length; } }
        /// <summary>
        /// If set to <c>true</c> the scanner enables deep search.
        /// When the scanner is in DeepSearch mode, search in all subdirectories via recursivity.
        /// </summary>
        public Boolean DeepSearch;
        /// <summary>
        /// If set to <c>true</c> the scanner will ommit errors during the search.
        /// Errors like accessing protected directories.
        /// </summary>
        public Boolean OmitErrors;
        /// <summary>
        /// The scanner start directory
        /// </summary>
        public DirectoryInfo StartDirectory;
        /// <summary>
        /// Initializes a new instance of the <see cref="AerithScanner"/> class.
        /// </summary>
        /// <param name="startDirectory">The scanner starting directory.</param>
        /// <param name="deepSearch">if set to <c>true</c> [enables scanner deep search].</param>
        /// <param name="omitErrors">if set to <c>true</c> [enable scanner to omit errors].</param>
        /// <exception cref="BlackMateriaException"></exception>
        public AerithScanner(DirectoryInfo startDirectory, Boolean deepSearch = false, Boolean omitErrors = false)
        {
            this.DeepSearch = deepSearch;
            this.StartDirectory = startDirectory;
            this.OmitErrors = omitErrors;
            if (!Directory.Exists(startDirectory.FullName))
                throw new BlackMateriaException(String.Format(ERR_DIR_MISSING, startDirectory.FullName));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AerithScanner"/> class.
        /// </summary>
        /// <param name="startDirectoryPath">The scanner starting directory path.</param>
        /// <param name="deepSearch">if set to <c>true</c> [enables scanner deep search].</param>
        /// <param name="omitErrors">if set to <c>true</c> [enable scanner to omit errors].</param>
        /// <exception cref="BlackMateriaException"></exception>
        public AerithScanner(String startDirectoryPath, Boolean deepSearch = false, Boolean omitErrors = false) :
            this(new DirectoryInfo(startDirectoryPath), deepSearch, omitErrors)
        {

        }
        /// <summary>
        /// Find all the files and directories from <see cref="StartDirectory"/>
        /// If <see cref="DeepSearch"/> is enable retrieves all sub directories and all files contained in 
        /// the root directory.
        /// </summary>
        /// <param name="filter">The scanner search filter.</param>
        /// <param name="findFileAction">Defines a costume action when a file is found.</param>
        /// <param name="findDirectoryAction">Defines a costume action when a directory is found.</param>
        /// <exception cref="BlackMateriaException"></exception>
        public void Find(AerithFilter filter = null, FileScannerHandler findFileAction = null, DirectoryScannerHandler findDirectoryAction = null)
        {
            try
            {
                List<FileInfo> files = new List<FileInfo>();
                List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                Object scnInput = new Object[] { files, dirs };
                this.Scan(ref scnInput, this.StartDirectory,
                    //Recolección de archivos
                    (ref Object input, DirectoryInfo startDirectory, FileInfo currentFile) =>
                    {
                        if ((filter == null) || (filter != null && filter.IsFileValid(currentFile)))
                        {
                            var fList = (scnInput as Object[])[0] as List<FileInfo>;
                            fList.Add(currentFile);
                            if (findFileAction != null)
                                findFileAction(ref input, startDirectory, currentFile);
                        }
                    },
                    ////Recolección de directorios
                    (ref Object input, DirectoryInfo startDirectory, DirectoryInfo currentDirectory) =>
                    {
                        if ((filter == null) || (filter != null && filter.IsDirectoryValid(currentDirectory)))
                        {
                            var dList = (scnInput as Object[])[1] as List<DirectoryInfo>;
                            dList.Add(currentDirectory);
                            if (findDirectoryAction != null)
                                findDirectoryAction(ref input, startDirectory, currentDirectory);
                        }
                    }, this.DeepSearch);
                this._Files = files.ToArray();
                this._Directories = dirs.ToArray();
            }
            catch (Exception exc)
            {
                if (!OmitErrors)
                    throw exc;
            }
        }
        /// <summary>
        /// Run a full scan on from <see cref="StartDirectory"/> find all directories, calculates tha directory size and retrieves the file found extensions
        /// If <see cref="DeepSearch"/> is enable retrieves all sub directories and all files contained in 
        /// the root directory.
        /// </summary>
        /// <param name="foundExtensions">The found extensions.</param>
        /// <param name="directorySize">Size of the directory.</param>
        /// <param name="filter">The scanner search filter.</param>
        /// <param name="findFileAction">Defines a costume action when a file is found.</param>
        /// <param name="findDirectoryAction">Defines a costume action when a directory is found.</param>
        public void FullScan(out String[] foundExtensions, out AerithSize directorySize,
            AerithFilter filter = null, FileScannerHandler findFileAction = null, DirectoryScannerHandler findDirectoryAction = null)
        {
            try
            {
                List<String> extensions = new List<string>();
                long size = 0;
                this.Find(filter,
                    //Se agregá al escaneo la recolección de extensiones y el calculo del tamaño del archivo
                    (ref Object input, DirectoryInfo startDirectory, FileInfo currentFile) =>
                    {
                        string ext = currentFile.Extension.Replace(".", "").ToUpper();
                        if (!extensions.Contains(ext))
                            extensions.Add(ext);
                        size += currentFile.Length;
                        if (findFileAction != null)
                            findFileAction(ref input, startDirectory, currentFile);
                    }, findDirectoryAction);
                directorySize = size.GetSizeFromBytes();
                foundExtensions = extensions.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get the size of the root directory
        /// </summary>
        public AerithSize GetSize()
        {
            try
            {
                Object scnInput = (long)0;
                Scan(ref scnInput, this.StartDirectory,
                    (ref object input, DirectoryInfo parentDirectory, FileInfo currentFile) =>
                    {
                        scnInput = (long)scnInput + currentFile.Length;
                    }, null, true);
                return ((long)scnInput).GetSizeFromBytes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Collects the file extensions contained on the directory and subdirectories.        
        /// If <see cref="DeepSearch"/> is enable retrieves all sub directories and all files contained in 
        /// the root directory.
        /// </summary>
        public String[] GetExtensions()
        {
            try
            {
                Object scnInput = new List<string>();
                Scan(ref scnInput, this.StartDirectory,
                    (ref object input, DirectoryInfo parentDirectory, FileInfo currentFile) =>
                    {
                        (scnInput as List<String>).Add(currentFile.Extension.Replace(".", "").ToUpper());
                    }, null, this.DeepSearch);
                return ((List<String>)scnInput).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Scans for files and directories parting from a root directory.
        /// When a directory is found a directory scan action is excecuted, and when a file is found
        /// a file scan action.
        /// </summary>
        /// <param name="input">The scanner input.</param>
        /// <param name="startDirectory">The start directory.</param>
        /// <param name="fileScanAction">The file scan action.</param>
        /// <param name="directoryScanAction">The directory scan action.</param>
        /// <param name="recursiveSearch">if set to <c>true</c> recursive search is enabled. 
        /// On recursive search the scanner searchs on all subdirectories</param>
        void Scan(ref Object input, DirectoryInfo startDirectory, FileScannerHandler fileScanAction = null, DirectoryScannerHandler directoryScanAction = null, Boolean recursiveSearch = true)
        {
            //Escaneo de directorios
            foreach (DirectoryInfo subDirectory in startDirectory.GetDirectories())
            {
                try
                {
                    if (recursiveSearch)
                        this.Scan(ref input, subDirectory, fileScanAction, directoryScanAction, recursiveSearch);
                    if (directoryScanAction != null)
                        directoryScanAction(ref input, startDirectory, subDirectory);
                }
                catch (Exception exc)
                {
                    if (OmitErrors)
                        continue;
                    else
                        throw exc.CreateNamelessException<BlackMateriaException>(ERR_SCANNING, subDirectory.FullName);
                }
            }
            //Escaneo de archivos
            foreach (FileInfo file in startDirectory.GetFiles())
            {
                try
                {
                    if (fileScanAction != null)
                        fileScanAction(ref input, startDirectory, file);
                }
                catch (Exception exc)
                {
                    if (OmitErrors)
                        continue;
                    else
                        throw exc.CreateNamelessException<BlackMateriaException>(ERR_SCANNING, file.FullName);
                }
            }
        }
    }
}