using Nameless.Libraries.Yggdrasil.Asuna;
using Nameless.Libraries.Yggdrasil.Lilith;
using Nameless.Libraries.Yggdrasil.Yuffie;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using IoFile = System.IO.File;
using IoFileInfo = System.IO.FileInfo;
using IoFileStream = System.IO.FileStream;
using System.Collections;
using Nameless.Libraries.Yggdrasil.Exceptions;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
using System.Linq;

namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// This class represents the medaka configuration file
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{Nameless.Libraries.Yggdrasil.Medaka.ConfigurationCategory}" />
    public class ConfigurationMedaka : NamelessObject, IEnumerable<ConfigurationCategory>
    {
        /// <summary>
        /// Access the medaka application
        /// </summary>
        public readonly MedakaApplication MedakaApp;
        /// <summary>
        /// The name of the application
        /// </summary>
        public String AppName { get { return MedakaApp.Name; } }
        /// <summary>
        /// The Configuration file categories
        /// </summary>
        public IEnumerable<ConfigurationCategory> Categories
        {
            get { return this.MedakaApp.Select(x => x.CreateCategory(this)); }
        }
        /// <summary>
        /// Gets the categories count.
        /// </summary>
        /// <value>
        /// Number of Categories defined on the configuration file.
        /// </value>
        public int Count
        {
            get { return this.Categories.Count(); }
        }
        /// <summary>
        /// Gets the <see cref="ConfigurationCategory"/> with the specified category name.
        /// </summary>
        /// <value>
        /// The <see cref="ConfigurationCategory"/>.
        /// </value>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns>The configuration category</returns>
        public ConfigurationCategory this[String categoryName]
        {
            get
            {
                if (this.MedakaApp.Contains(categoryName))
                    return this.MedakaApp[categoryName].CreateCategory(this);
                else
                    return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationMedaka"/> class.
        /// </summary>
        /// <param name="config_File">The configuration file.</param>
        /// <param name="appName">Name of the application.</param>
        public ConfigurationMedaka(IoFileInfo config_File, string appName)
        {
            string aName = appName.ToXmlName();
            try
            {
                //1: Checamos la existencia del archivo, en caso de no existir lo creamos
                this.CheckFile(config_File.FullName);
                //2: Se carga el xml de memoria
                var xml = new XNpc(aName, config_File);
                this.MedakaApp = new MedakaApplication(xml, aName);
            }
            catch (Exception exc)
            {
                throw exc.CreateNamelessException<BlackMateriaException>(ERR_INIT_MEDAKA);
            }
        }
        /// <summary>
        /// Adds the specified category.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        public void Add(String categoryName)
        {
            if (!this.MedakaApp.Contains(categoryName))
                this.MedakaApp.Add(new XElement(categoryName));
            else
                throw new GodModeException(String.Format(ERR_CAT_DUPLICATED, categoryName));
        }
        /// <summary>
        /// Clear the configuration file
        /// </summary>
        public void Clear()
        {
            this.MedakaApp.Children.ToList().ForEach(x => x.Delete());
        }
        /// <summary>
        /// Get the configuration category enumerator
        /// </summary>
        /// <returns>
        /// Returns category enumerator
        /// </returns>
        public IEnumerator<ConfigurationCategory> GetEnumerator()
        {
            return this.Categories.GetEnumerator();
        }
        /// <summary>
        /// Get the configuration category enumerator
        /// </summary>
        /// <returns>
        /// Returns category enumerator
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Categories.GetEnumerator();
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.MedakaApp.Xml.ToString();
        }
        /// <summary>
        /// Check if the file exist if the file does not exist is created
        /// </summary>
        /// <param name="filePath">The file path</param>
        private void CheckFile(string filePath)
        {
            try
            {
                if (!IoFile.Exists(filePath))
                    IoFile.Create(filePath).Close();
            }
            catch (Exception exc)
            {
                throw exc.CreateNamelessException<GodModeException>(ERR_CREATING_FILE);
            }
        }
    }
}