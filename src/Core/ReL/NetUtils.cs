using Nameless.Libraries.Yggdrasil.Exceptions;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Net;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.ReL
{
    /// <summary>
    /// Defines a Net Tools class utility
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public static class NetUtils
    {
        /// <summary>
        /// Gets the file from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The bytes of the file</returns>
        /// <exception cref="ErgoProxyException">
        /// </exception>
        public static byte[] GetFileFromUrl(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadData(url);
                }
            }
            catch (Exception exc)
            {
                throw exc.CreateNamelessException<ErgoProxyException>(ERR_DOWNLOADING, url);
            }
        }
    }
}
