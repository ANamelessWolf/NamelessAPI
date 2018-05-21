using Nameless.Libraries.Yggdrasil.Asuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
using static Nameless.Libraries.Yggdrasil.Lilith.LilithConstants;
namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// This class represents the application node in a Medaka configuration file.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.XUniqueCollection" />
    public class MedakaApplication : XUniqueCollection
    {
        /// <summary>
        /// The configuration file as an XML, treated as XNPC
        /// </summary>
        public readonly XNpc Xml;
        /// <summary>
        /// The application name is the name of the root node
        /// </summary>
        protected readonly String ApplicationName;
        /// <summary>
        /// Define the attribute entries for the XElement
        /// </summary>
        public virtual XAttributeEntry[] ApplicationAttributeDefinition
        {
            get
            {
                return
                  new XAttributeEntry[]
                  {
                        new XAttributeEntry(ATT_APP_VERSION, DEFAULT_VERSION),
                        new XAttributeEntry(ATT_APP_LAST_ACCESS, DEFAULT_DATE)
                  };
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MedakaApplication"/> class.
        /// </summary>
        /// <param name="xml">The configuration XML file.</param>
        /// <param name="appName">Name of the application.</param>
        public MedakaApplication(XNpc xml, String appName) :
            base(GetRoot(xml, appName))
        {
            this.Xml = xml;
            this.ApplicationName = appName;
            this.InitAttributes();
        }
        /// <summary>
        /// Gets the root XElement
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="appName">Name of the application.</param>
        /// <returns>The root XElement</returns>
        private static XElement GetRoot(XNpc xml, string appName)
        {
            if (GetStatus(xml.Document, appName) == ConfigStatus.Damage)
                xml.CreateDocument();
            return xml.Document.Elements(appName).FirstOrDefault();
        }
        /// <summary>
        /// Get the current configuration file status
        /// </summary>
        /// <returns>The current configuration status</returns>
        private static ConfigStatus GetStatus(XDocument doc, string appName)
        {
            ConfigStatus conStatus = ConfigStatus.Ok;
            XElement appNode = doc.Elements(appName).FirstOrDefault();
            if (appNode != null && appNode.Elements().Count() == 0)
                conStatus = ConfigStatus.Empty;
            else if (appNode == null)
                conStatus = ConfigStatus.Damage;
            return conStatus;
        }
        /// <summary>
        /// Initializes the attributes.
        /// </summary>
        private void InitAttributes()
        {
            foreach (var att in ApplicationAttributeDefinition)
                if (!this.HasAttribute(att.AttributeName))
                    this.AddAttribute(att.AttributeName, att.AttributeValue);
        }
    }
}
