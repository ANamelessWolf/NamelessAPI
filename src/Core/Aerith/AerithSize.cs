using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Text;
using static Nameless.Libraries.Yggdrasil.Aerith.AerithUtils;
namespace Nameless.Libraries.Yggdrasil.Aerith
{
    /// <summary>
    /// This class defines a unit of digital information that consists on bytes.
    /// Also shows the size formatted on a  human-readable format
    /// </summary>
    public class AerithSize : NamelessObject
    {
        /// <summary>
        /// Gets the total kilo bytes.
        /// </summary>
        /// <value>
        /// The total kilo bytes.
        /// </value>
        public double TotalKiloBytes { get { return GetTotalSize(KB); } }
        /// <summary>
        /// Gets the total mega bytes.
        /// </summary>
        /// <value>
        /// The total mega bytes.
        /// </value>
        public double TotalMegaBytes { get { return GetTotalSize(MB); } }
        /// <summary>
        /// Gets the total giga bytes.
        /// </summary>
        /// <value>
        /// The total giga bytes.
        /// </value>
        public double TotalGigaBytes { get { return GetTotalSize(GB); } }
        /// <summary>
        /// Gets the total tera bytes.
        /// </summary>
        /// <value>
        /// The total tera bytes.
        /// </value>
        public double TotalTeraBytes { get { return GetTotalSize(TB); } }
        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <value>
        /// The bytes.
        /// </value>
        public long Bytes { get { return _lengthArray[0]; } }
        /// <summary>
        /// Gets the kylo bytes.
        /// </summary>
        /// <value>
        /// The kylo bytes.
        /// </value>
        public long KyloBytes { get { return _lengthArray[1]; } }
        /// <summary>
        /// Gets the mega bytes.
        /// </summary>
        /// <value>
        /// The mega bytes.
        /// </value>
        public long MegaBytes { get { return _lengthArray[2]; } }
        /// <summary>
        /// Gets the giga bytes.
        /// </summary>
        /// <value>
        /// The giga bytes.
        /// </value>
        public long GigaBytes { get { return _lengthArray[3]; } }
        /// <summary>
        /// Gets the tera bytes.
        /// </summary>
        /// <value>
        /// The tera bytes.
        /// </value>
        public long TeraBytes { get { return _lengthArray[4]; } }
        /// <summary>
        /// Gets ore sets the total bytes.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public long Length { get { return _length; } set { this.Refresh(value); } }
        /// <summary>
        /// The size length in bytes
        /// </summary>
        long _length;
        /// <summary>
        /// The size length array
        /// </summary>
        long[] _lengthArray;
        /// <summary>
        /// Initializes a new instance of the <see cref="AerithSize"/> class.
        /// </summary>
        /// <param name="totalBytes">Total bytes.</param>
        public AerithSize(long totalBytes)
        {
            this.Length = totalBytes;
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents a information unit size in human-readable format.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this information size.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            String[] formats = new String[] { "B", "KB", "MB", "GB", "TB" };

            for (int i = formats.Length - 1; i > 0; i--)
                if (this._lengthArray[i] != 0)
                {
                    sb.Append(this._lengthArray[i]);
                    sb.Append(" " + formats[i] + ", ");
                }
            if (sb.ToString().Length - 2 > 0)
                return sb.ToString().Substring(0, sb.ToString().Length - 2);
            else
                return "0 B";
        }
        /// <summary>
        /// Refresh the current size
        /// </summary>
        /// <param name="value">The file size value</param>
        void Refresh(long value)
        {
            var tmp = value;
            this._lengthArray = new long[5];
            long[] formats = new long[] { B, KB, MB, GB, TB };
            for (int i = (formats.Length - 1); i > 0; i--)
                if (value >= formats[i])
                {
                    this._lengthArray[i] = value / formats[i];
                    value = value - this._lengthArray[i] * formats[i];
                }
                else
                    this._lengthArray[i] = 0;
            this._length = tmp;
        }
        /// <summary>
        /// Gets the total size in the specific Formatter.
        /// </summary>
        /// <param name="unitSize">The selected units.</param>
        /// <returns>The total size</returns>
        double GetTotalSize(long unitSize)
        {
            if (this.Length >= unitSize)
                return (double)this.Length / (double)unitSize;
            else
                return 0;
        }
    }
}
