using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Linq;
using System.Text;

namespace Nameless.Libraries.Yggdrasil.Alice
{
    /// <summary>
    /// This class converts a string in to binary, hex and ascii input.
    /// Tweedledum and Tweedledee
    ///     Agreed to have a battle;
    /// For Tweedledum said Tweedledee
    ///     Had spoiled his nice new rattle.
    /// Just then flew down a monstrous crow,
    ///     As black as a tar-barrel;
    /// Which frightened both the heroes so,
    ///     They quite forgot their quarrel.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class Tweedle : NamelessObject
    {
        /// <summary>
        /// The input message could be in binary or in ascii or in hex
        /// </summary>
        public string Input;
        /// <summary>
        /// Initializes a new instance of the <see cref="Tweedle"/> class.
        /// </summary>
        /// <param name="input">The input message as binary or ascii.</param>
        public Tweedle(String input)
        {
            this.Input = input;
        }
        /// <summary>
        /// Changes the input to binary code.
        /// </summary>
        /// <returns>A binary string</returns>
        public string ToBinary()
        {
            byte[] bytes = this.Input.GetBytes();
            String result = String.Empty;
            foreach (byte b in bytes)
                result += Convert.ToString(b, 2);
            return result;
        }
        /// <summary>
        /// Changes the input to hex code.
        /// </summary>
        /// <returns>A hex string</returns>
        public string ToHex()
        {
            byte[] bytes = this.Input.GetBytes();
            String result = String.Empty;
            foreach (byte b in bytes)
                result += Convert.ToString(b, 16);
            return result;
        }
        /// <summary>
        /// Changes the input to asscii code.
        /// </summary>
        /// <returns>An input string</returns>
        public string ToAscii()
        {

            String input = this.Input,
                   val, hex, result = String.Empty;

            //Se toma como binaria la entrada
            if (this.Input.Count(x => x == 0 || x == 1) == this.Input.Length)
            {
                while (input.Length > 0)
                {
                    if (input.Length >= 8)
                    {
                        val = input.Substring(0, 8);
                        input = input.Substring(8);
                    }
                    else
                    {
                        val = String.Format("{0:00000000}", input);
                        input = String.Empty;
                    }
                    hex = String.Format("{0:X2}", Convert.ToUInt64(val, 2));
                    result += (char)Convert.ToInt32(hex, 16);

                }
            }
            //Se toma como hexadecimal la entrada
            else if (this.Input.Count(x => "0123456789ABCDEF".Contains(x)) == this.Input.Length)
            {
                while (input.Length > 0)
                {
                    if (input.Length >= 2)
                    {
                        val = input.Substring(0, 2);
                        input = input.Substring(2);
                    }
                    else
                    {
                        val = String.Format("{0:00}", input);
                        input = String.Empty;
                    }
                    result += (char)Convert.ToInt32(val, 16);
                }
            }
            //En otro caso se piensa que esta en asscii
            else
                result = this.Input;
            return result;
        }
    }
}
