using Nameless.Libraries.Yggdrasil.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Lilith
{
    /// <summary>
    /// This class manage runtime and core actions
    /// </summary>
    public static class NamelessUtils
    {
        /// <summary>
        /// Formats the exception message.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <param name="costumeMsg">The costume message to be formatted with the exception.</param>
        /// <returns>The formatted exception message</returns>
        public static String FormatExceptionMessage(this Exception exc, string costumeMsg)
        {
            return exc.InnerException == null ? String.Format("{0}: {1}", costumeMsg, exc.Message) :
                String.Format("{0}: Exception: {1}\n InnerException: {2}", costumeMsg, exc.Message, exc.InnerException.Message);
        }
        /// <summary>
        /// Formats the exception message.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <returns>The formatted exception message</returns>
        public static String FormatExceptionMessage(this Exception exc)
        {
            return exc.InnerException == null ? exc.Message :
                String.Format("{0}, InnerException: {1}", exc.Message, exc.InnerException.Message);
        }
        /// <summary>
        /// Gets the application directory.
        /// </summary>
        /// <param name="type">A type from the class application directory.</param>
        /// <returns>The application directory</returns>
        public static DirectoryInfo GetApplicationDirectory(this Type type)
        {
            return new DirectoryInfo(Path.GetDirectoryName(type.GetAssemblyLocation()));
        }
        /// <summary>
        /// Gets the assembly location.
        /// </summary>
        /// <param name="type">A type of the class that belongs to the assembly.</param>
        /// <returns>The assembly location</returns>
        public static String GetAssemblyLocation(this Type type)
        {
            return Assembly.GetAssembly(type).Location;
        }
        /// <summary>
        /// Throws an excepetion in formatted text
        /// </summary>
        /// <param name="exc">The exception to be formatted.</param>
        /// <param name="msg">The exception message.</param>
        /// <param name="msg_params">The exeption message parameters</param>
        /// <returns>The formatted exception message</returns>
        public static T CreateNamelessException<T>(this Exception exc, string msg, params String[] msg_params) where T : NamelessException
        {
            var type = typeof(T);
            string excMsg = msg;
            if (msg != null && msg.Length > 0)
                excMsg = String.Format(msg, msg_params);
            object nExc = Activator.CreateInstance(type, excMsg, exc);
            return nExc as T;
        }
        /// <summary>
        /// Meet the maker
        /// The Nameless Author, the API maker.
        /// </summary>
        /// <param name="nm">The nameless interface</param>
        public static String GetAuthor(this INameless nm)
        {
            return nm.Nameless.Author;
        }
        /// <summary>
        /// The Nameless Company
        /// </summary>
        public static String GetCompany(this INameless nm)
        {
            return nm.Nameless.Company;
        }
        /// <summary>
        /// The namespace of the current project.
        /// </summary>
        public static String GetNamespace(this INameless nm)
        {
            return nm.Nameless.Namespace;
        }
        /// <summary>
        /// The class name that generate the exception.
        /// </summary>
        public static String GetClass(this INameless nm)
        {
            return nm.Nameless.Class;
        }
        /// <summary>
        /// The class name that generate the exception.
        /// </summary>
        public static String GetAPI(this INameless nm)
        {
            return nm.Nameless.API;
        }
        /// <summary>
        /// The method or function that is currently running
        /// </summary>
        public static String GetMethodName(this INameless nm)
        {
            return nm.Nameless.MethodName;
        }
        /// <summary>
        /// Gets the compilation date
        /// </summary>
        public static String GetCompileDate(this INameless nm)
        {
            return nm.Nameless.CompileDate;
        }
        /// <summary>
        /// The current version of the software.
        /// </summary>
        public static String GetVersion(this INameless nm)
        {
            return nm.Nameless.Version;
        }
        /// <summary>
        /// Gets the Nameless Data
        /// </summary>
        public static String GetNamelessData(this INameless nm)
        {
            return nm.Nameless.NamelessData;
        }
        /// <summary>
        /// Gets the id for the given Object
        /// </summary>
        public static Guid GetId(this INameless nm)
        {
            return nm.Nameless.Id;
        }

    }
}
