using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Lilith
{
    /// <summary>
    /// Manage the application Local Resources and Language
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class Babel : NamelessObject
    {
        /// <summary>
        /// Change the Application Language
        /// </summary>
        public SupportedLanguage Langle
        {
            get
            {
                return _langle;
            }
            set
            {
                this._langle = value;
                SelectLanguage(this._langle);
            }
        }
        /// <summary>
        /// Returns the current culture
        /// </summary>
        public CultureInfo Culture
        {
            get { return SelectLanguage(this._langle); }
        }
        /// <summary>
        /// Add a resource to the Babel Manager
        /// </summary>
        public delegate void ResourceTranslator(CultureInfo culture);
        SupportedLanguage _langle;
        /// <summary>
        /// Creates a new language manager
        /// </summary>
        /// <param name="langle">The language</param>
        public Babel(SupportedLanguage langle, ResourceTranslator translator)
        {
            this.Langle = langle;
            CultureInfo ci = this.Culture;
            Assets.Strings.Culture = ci;
            translator(ci);
        }
        /// <summary>
        /// Select the Culture
        /// </summary>
        /// <param name="langle">The selected language</param>
        /// <returns>The current cultural info</returns>
        public static CultureInfo SelectLanguage(SupportedLanguage langle)
        {
            CultureInfo ci;
            if (langle == SupportedLanguage.Spanish)
                ci = new CultureInfo("es");
            else
                ci = new CultureInfo("en");
            return ci;
        }
        /// <summary>
        /// Gets the current language supported content.
        /// </summary>
        /// <value>
        /// The current language support.
        /// </value>
        public static SupportedLanguage Current 
        {
            get
            {
                String cu = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                if (cu == "es")
                    return SupportedLanguage.Spanish;
                else
                    return SupportedLanguage.English;
            }
        }
    }
}
