using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6.Answes
{
    public class CompressorSimple : ICompressor
    {
        public string Compress(string txt)
        {
            if(string.IsNullOrEmpty(txt))
            {
                return txt;
            }

            var ret = new StringBuilder();

            int count = 0;
            char currentChar = '\0';

            for(var i = 0; i < txt.Length; i++, count++)
            {
                if(txt[i] != currentChar)
                {
                    // Skip to initialize everything on first iteration
                    if (i != 0)
                    {
                        ret.Append(GetCompressedString(currentChar, count));
                    }

                    currentChar = txt[i];
                    count = 0;
                }
            }

            ret.Append(GetCompressedString(currentChar, count));

            return ret.ToString();
        }

        /// <summary>
        /// Returns the string representing the compressed character series.
        /// </summary>
        /// <param name="c">The character</param>
        /// <param name="count">The number of consecutive characters</param>
        /// <returns>The string representing the characters</returns>
        /// <remarks>
        /// This isn't what the book is asking for, but only include the number if there's at least 2 characters.
        /// This will improve the algorithm by not increasing the size of single characters.
        /// </remarks>
        private string GetCompressedString(char c, int count)
        {
            if (count > 1)
            {
                return $"{c}{count}";
            }
            else
            {
                return $"{c}";
            }
        }
    }
}
