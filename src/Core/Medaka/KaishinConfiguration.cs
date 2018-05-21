using Nameless.Libraries.Yggdrasil.Asuna;
using Nameless.Libraries.Yggdrasil.Exceptions;
using Nameless.Libraries.Yggdrasil.Lain;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Globalization;
using System.IO;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// An abstract class dedicated to create an application class with a configuration file used in nameless applications.
    /// Kaishin is the Alter God Mode of Medaka Kurokami
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Medaka.IMedakaApplication" />
    public abstract class KaishinConfiguration : NamelessObject, IMedakaApplication
    {
        /// <summary>
        /// The configuration file
        /// </summary>
        public ConfigurationMedaka Configuration;
        /// <summary>
        /// Application log
        /// </summary>
        public WiredGhost Log;
        /// <summary>
        /// Gets the categories of the Kaishin configuration file.
        /// </summary>
        /// <value>
        /// The kaishin files categories.
        /// </value>
        protected abstract CategoryDefinition[] Categories { get; }
        /// <summary>
        /// The name of the current application
        /// </summary>
        public String ApplicationName { get { return this.Configuration.AppName; } }
        /// <summary>
        /// Gets the name of the application log.
        /// </summary>
        /// <value>
        /// The name of the application log.
        /// </value>
        protected String AppLogName { get { return String.Format("{0}.log", this.ApplicationName); } }
        /// <summary>
        /// This flag enables auto save to the configuration file automatically.
        /// Properties are save automatically
        /// </summary>
        public Boolean AutoSave;
        /// <summary>
        /// Gets the application directory.
        /// </summary>
        /// <value>
        /// The application directory.
        /// </value>
        public DirectoryInfo AppDirectory { get { return typeof(KaishinConfiguration).GetApplicationDirectory(); } }
        /// <summary>
        /// Gets the configuration file.
        /// </summary>
        /// <value>
        /// The configuration file.
        /// </value>
        public FileInfo ConfigurationFile { get { return new FileInfo(Path.Combine(AppDirectory.FullName, STR_MEDAKA_FILE)); } }
        /// <summary>
        /// Gets or sets the property value <see cref="String"/> with the specified category.
        /// </summary>
        /// <value>
        /// The property value <see cref="String"/>.
        /// </value>
        /// <param name="catName">The category name.</param>
        /// <param name="propName">The property name.</param>
        /// <returns>The property value</returns>
        /// <exception cref="GodModeException">An Exception is thrown if the category does exists or the property does not exists</exception>
        public String this[String catName, String propName]
        {
            get
            {
                try
                {
                    return this.Configuration[catName][propName];
                }
                catch (Exception exc)
                {
                    throw exc.CreateNamelessException<GodModeException>(String.Format(ERR_PROPERTY_NOT_FOUND, propName, catName));
                }
            }
            set
            {
                try
                {
                    this.Configuration[catName][propName] = value;
                    if (AutoSave)
                        this.Save();
                }
                catch (Exception exc)
                {
                    throw exc.CreateNamelessException<GodModeException>(String.Format(ERR_PROPERTY_NOT_FOUND, propName, catName));
                }
            }
        }
        /// <summary>
        /// Gets the <see cref="ConfigurationCategory"/> with the specified category name.
        /// </summary>
        /// <value>
        /// The <see cref="ConfigurationCategory"/>.
        /// </value>
        /// <param name="catName">Name of the category.</param>
        /// <returns>The configuration category</returns>
        public ConfigurationCategory this[String catName]
        {
            get
            {
                try
                {
                    return this.Configuration[catName];
                }
                catch (Exception exc)
                {
                    throw exc.CreateNamelessException<GodModeException>(String.Format(ERR_CAT_NOT_FOUND, catName));
                }
            }
        }
        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        public virtual string AppVersion
        {
            get
            {
                return LilithConstants.DEFAULT_VERSION;
            }
            set
            {
                (this.Configuration.MedakaApp as XData).SetAttribute(ATT_APP_VERSION, value);
                this.Save();
            }
        }
        /// <summary>
        /// Gets or sets the last access date.
        /// </summary>
        /// <value>
        /// The last access date.
        /// </value>
        public virtual DateTime Last_Access
        {
            get
            {
                String dtStr = (this.Configuration.MedakaApp as XData).GetAttribute(ATT_APP_LAST_ACCESS);
                DateTime dt = DateTime.ParseExact(dtStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            set
            {
                String dtStr = String.Format("{0}/{1}/{2}", String.Format("{0:00}", value.Day), String.Format("{0:00}", value.Month), value.Year);
                (this.Configuration.MedakaApp as XData).SetAttribute(ATT_APP_LAST_ACCESS, dtStr);
                this.Save();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="KaishinConfiguration"/> class.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="logIsEnabled">if set to <c>true</c> [log is enabled].</param>
        /// <exception cref="GodModeException"></exception>
        public KaishinConfiguration(String appName, Boolean logIsEnabled = false)
        {
            try
            {
                this.Configuration = new ConfigurationMedaka(this.ConfigurationFile, appName);
                FileInfo logFile = new FileInfo(Path.Combine(this.AppDirectory.FullName, this.AppLogName));
                this.Log = new WiredGhost(logFile, logIsEnabled);
                this.Log.GhostMode = logIsEnabled;
                this.InitConfiguration(this.Configuration);
                this.Configuration.MedakaApp.Xml.Save();
            }
            catch (Exception exc)
            {
                exc.CreateNamelessException<GodModeException>(exc.Message);
            }
        }
        /// <summary>
        /// Save the current xml
        /// </summary>
        public void Save()
        {
            this.Configuration.MedakaApp.Xml.Save();
        }
        /// <summary>
        /// Initializes the configuration.
        /// </summary>
        /// <param name="conf">The configuration file.</param>
        protected void InitConfiguration(ConfigurationMedaka medaka)
        {
            var appNode = medaka.MedakaApp;
            ConfigurationCategory catNode;
            foreach (var cat in this.Categories)
            {
                if (!appNode.Contains(cat.CategoryName))
                    medaka.Add(cat.CategoryName);
                catNode = medaka[cat.CategoryName];
                foreach (var prop in cat.Properties)
                    if (!catNode.Contains(prop.Key))
                        catNode.Add(prop.Key, prop.Value);
            }
            this.SetApplicationInformation();
        }
        /// <summary>
        /// Sets the application information.
        /// </summary>
        public void SetApplicationInformation()
        {
            this.AppVersion = LilithConstants.DEFAULT_VERSION;
            this.Last_Access =DateTime.ParseExact(LilithConstants.DEFAULT_DATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.Save();
        }
    }
}