using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Frau.NET
{
    /// <summary>
    /// This class manage the networking connectivity
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class Networking : NamelessObject
    {
        /// <summary>
        /// The Ip result
        /// </summary>
        public IPAddress[] IP_Result;
        /// <summary>
        /// The Ip Result IPV4 addresses
        /// </summary>
        public IEnumerable<IPAddress> IPV4 { get {return IP_Result.Where(X=> X.AddressFamily== AddressFamily.InterNetwork); } }

        /// <summary>
        /// Display the ip of a given hostname, if the hostname is empty
        /// The Host will be the local machine
        /// The result is Saved in the IP_Result property
        /// </summary>
        /// <param name="hostName">The name of the host</param>
        public void ShowIp(String hostName = "")
        {
            string name = hostName != "" ? hostName : Dns.GetHostName();
            try
            {
                this.IP_Result = Dns.GetHostEntry(name).AddressList;
            }
            catch (Exception)
            {
                this.IP_Result = new IPAddress[0];
            }
        }
    }
}
