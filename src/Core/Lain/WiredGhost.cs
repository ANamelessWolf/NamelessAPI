using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.IO;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Lain
{
    /// <summary>
    /// This is the agent that creates a log file for an application, an reports the application
    /// progress. In Serial Experiments Lain, Lain Iwakura was the main character she lacks from emotions
    /// and when she is plugged to a computer she resembles a wired ghost, that can report anything in 
    /// the world.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class WiredGhost : NamelessObject
    {
        /// <summary>
        /// Enables or disable the use of the log.
        /// </summary>
        public bool GhostMode { set; get; }
        /// <summary>
        /// Gets the date format.
        /// </summary>
        /// <value>
        /// The date format.
        /// </value>
        protected string DateFormat { get { return String.Format("[{0:d/M/yyyy HH:mm:ss}]", DateTime.Now); } }
        FileInfo Log;
        /// <summary>
        /// Initializes a new instance of the <see cref="WiredGhost"/> class.
        /// </summary>
        /// <param name="logFile">The log file.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public WiredGhost(FileInfo logFile, Boolean enable = false)
        {
            if (!File.Exists(logFile.FullName))
                File.Create(logFile.FullName).Close();
            this.GhostMode = enable;
            this.Log = logFile;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WiredGhost"/> class.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public WiredGhost(String logFilePath, Boolean enable = false) :
            this(new FileInfo(logFilePath), enable)
        {
        }
        /// <summary>
        /// Appends an entry to the log.
        /// </summary>
        /// <param name="msg">The entry message.</param>
        /// <param name="type">The protocol type.</param>
        /// <param name="functionName">The function name.</param>
        /// <param name="specialCaption">Adds a special caption to entry.</param>
        public void AppendEntry(string msg, Protocol type, string functionName, string specialCaption = "")
        {
            if (this.GhostMode)
                this.Save(this.CreateEntryMessage(msg, type, functionName, specialCaption));
        }
        /// <summary>
        /// Appends an entry to the log.
        /// </summary>
        /// <param name="msg">The entry message.</param>
        /// <param name="type">The protocol type.</param>
        /// <param name="nameless">The nameless object.</param>
        public void AppendEntry(string msg, Protocol type, NamelessObject nameless)
        {
            this.AppendEntry(msg, type, nameless.MethodName, nameless.Class);
        }
        /// <summary>
        /// Appends an entry to the log.
        /// </summary>
        /// <param name="msg">The entry message.</param>
        /// <param name="type">The protocol type.</param>
        /// <param name="nameless">The nameless object.</param>
        public void AppendEntry(string msg, Protocol type, INameless nameless)
        {
            this.AppendEntry(msg, type, nameless.Nameless.MethodName, nameless.Nameless.Class);
        }
        /// <summary>
        /// Adds a new entry to the log.
        /// </summary>
        /// <param name="msg">The entry message.</param>
        public void AppendEntry(string msg)
        {
            if (this.GhostMode)
                this.Save(string.Format("{0} {1}\n", this.DateFormat, msg));
        }
        /// <summary>
        /// Appends the entry.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <param name="nameless">Extract the information from the nameless Object</param>
        /// <param name="printStackTrace">if set to <c>true</c> [print stack trace].</param>
        public void AppendEntry(Exception exc, NamelessObject nameless, Boolean printStackTrace = false)
        {
            if (this.GhostMode)
            {
                string entry;
                //Se generá la entrada del Log
                if (nameless != null)
                    entry = this.CreateEntryMessage(exc.FormatExceptionMessage(), Protocol.Error, nameless.MethodName, nameless.Class);
                else
                    entry = this.CreateEntryMessage(exc.FormatExceptionMessage(), Protocol.Error);
                //Se imprime el stack trace
                if (printStackTrace)
                    entry += "\n" + exc.StackTrace;
                this.Save(entry);
            }
        }
        /// <summary>
        /// Appends the entry.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <param name="nameless">Extract the information from the nameless Object</param>
        /// <param name="printStackTrace">if set to <c>true</c> [print stack trace].</param>
        public void AppendEntry(Exception exc, INameless nameless)
        {
            this.AppendEntry(exc, nameless.Nameless, false);
        }
        /// <summary>
        /// Appends the entry.
        /// </summary>
        /// <param name="exc">The exc.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="className">Name of the class.</param>
       public void AppendEntry(Exception exc, String functionName, String className)
        {
            var entry = this.CreateEntryMessage(exc.FormatExceptionMessage(), Protocol.Error, functionName, className);
            this.AppendEntry(entry);
        }
        /// <summary>
        /// Adds an entry to the log and Saves it.
        /// </summary>
        /// <param name="logEntry">The message log.</param>
        /// <param name="textWriter">The text writer.</param>
        private void Save(string logEntry)
        {
            try
            {
                using (StreamWriter w = File.AppendText(this.Log.FullName))
                    w.Write(logEntry);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Formats the entry.
        /// </summary>
        /// <param name="entry">The entry value.</param>
        /// <returns>The entry formatted</returns>
        private String FormatEntry(Object entry)
        {
            if ((entry is String) && ((entry as String) == null || (entry as String) == ""))
                return String.Empty;
            else
                return String.Format("[{0}]", entry);
        }
        /// <summary>
        /// Creates the entry message.
        /// </summary>
        /// <param name="msg">The entry message.</param>
        /// <param name="protocol">The protocol type.</param>
        /// <param name="functionName">The function name.</param>
        /// <param name="spCaption">The special caption.</param>
        /// <returns>The entry message</returns>
        private String CreateEntryMessage(String msg, Protocol protocol, String functionName = "", String spCaption = "")
        {
            String entry = String.Empty,
                   entryType = this.FormatEntry(protocol),
                   caption = this.FormatEntry(spCaption),
                   fName = this.FormatEntry(functionName),
                   date = this.DateFormat;
            if (spCaption == String.Empty && fName != String.Empty)
                entry = string.Format("{0, -10}{1, -30}{2,-35}", entryType, date, fName);
            else if (spCaption != String.Empty && fName == String.Empty)
                entry = string.Format("{0, -10}{1, -30}{2,-20}", entryType, caption, date);
            else if (spCaption == "" && fName == "")
                entry = string.Format("{0, -10}{1, -30}", entryType, date);
            else
                entry = string.Format("{0, -10}{1, -30}{2,-20}{3,-35}", entryType, caption, date, fName);
            entry += String.Format(STR_FORMAT_LAIN_ENTRY, msg);
            return msg;
        }
    }
}
