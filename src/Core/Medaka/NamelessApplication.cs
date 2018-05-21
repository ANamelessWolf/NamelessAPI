using Nameless.Libraries.Yggdrasil.Alice;
using Nameless.Libraries.Yggdrasil.Asuna;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
using static Nameless.Libraries.Yggdrasil.Lilith.LilithConstants;
namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// This class defines a Nameless Application
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Medaka.KaishinConfiguration" />
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Alice.IPupa" />
    public class NamelessApplication : KaishinConfiguration, IPupa
    {
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The developer.
        /// </value>
        public new String Company
        {
            get
            {
                return this[CAP_NAMELESS, STR_PROPERTY_COMPANY];
            }
            set
            {
                this[CAP_NAMELESS, STR_PROPERTY_COMPANY] = value;
            }
        }
        /// <summary>
        /// Gets or sets the developer.
        /// </summary>
        /// <value>
        /// The developer.
        /// </value>
        public String Developer
        {
            get
            {
                return this[CAP_NAMELESS, STR_PROPERTY_DEVELOPER];
            }
            set
            {
                this[CAP_NAMELESS, STR_PROPERTY_DEVELOPER] = value;
            }
        }
        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        public override string AppVersion
        {
            get
            {
                SuccubusAssembly succubus = new SuccubusAssembly(typeof(NamelessApplication));
                return succubus.ShortVersion;

            }
            set => base.AppVersion = value;
        }
        /// <summary>
        /// Gets the categories of the Kaishin configuration file.
        /// </summary>
        /// <value>
        /// The kaishin files categories.
        /// </value>
        protected override CategoryDefinition[] Categories
        {
            get
            {
                return new CategoryDefinition[]
                {
                    new CategoryDefinition(CAP_NAMELESS,
                        new KeyValuePair<string, string>(STR_PROPERTY_API_VERSION, new SuccubusAssembly(typeof(NamelessApplication)).ShortVersion),
                        new KeyValuePair<string, string>(STR_PROPERTY_LAST_COMPILE_DATE, new FileInfo(typeof(NamelessApplication).GetAssemblyLocation()).LastWriteTime.ToShortDateString()),
                        new KeyValuePair<string, string>(STR_PROPERTY_DEVELOPER, DEVELOPER),
                        new KeyValuePair<string, string>(STR_PROPERTY_COMPANY, COMPANY))
                };
            }
        }
        /// <summary>
        /// Gets the application encryption key.
        /// </summary>
        /// <value>
        /// The encryption key values.
        /// </value>
        public byte[] Key
        {
            get
            {
                return KeyString.GetBytes();
            }
        }
        /// <summary>
        /// Gets the application encryption vector.
        /// </summary>
        /// <value>
        /// The encryption key values.
        /// </value>
        public byte[] IV
        {
            get
            {
                return IVString.GetBytes();
            }
        }
        /// <summary>
        /// Gets or sets the key string.
        /// </summary>
        /// <value>
        /// The key string.
        /// </value>
        public virtual string KeyString
        {
            get { return this._Key; }
            set { this._Key = value; }
        }
        /// <summary>
        /// The application encryption key
        /// </summary>
        string _Key = NAMELESS_KEY;
        /// <summary>
        /// Gets or sets the vector string.
        /// </summary>
        /// <value>
        /// The vector string.
        /// </value>
        public virtual string IVString
        {
            get { return this._IV; }
            set { this._IV = value; }
        }
        /// <summary>
        /// The application encryption vector
        /// </summary>
        string _IV = NAMELESS_IV;
        /// <summary>
        /// Initializes a new instance of the <see cref="NamelessApplication"/> class.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="logIsEnabled">if set to <c>true</c> [log is enabled].</param>
        public NamelessApplication(String appName, Boolean logIsEnabled = false) :
                base(appName, logIsEnabled)
        {

        }
        /// <summary>
        /// Encrypts the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// The string encrypted
        /// </returns>
        public String Encrypt(String str)
        {
            Caterpillar cat = new Caterpillar(this.Key, this.IV);
            return cat.Encrypt(str);
        }
        /// <summary>
        /// Decrypts the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// The string decrypted
        /// </returns>
        public String Decrypt(String str)
        {
            Caterpillar cat = new Caterpillar(this.Key, this.IV);
            return cat.Decrypt(str);
        }
    }
}