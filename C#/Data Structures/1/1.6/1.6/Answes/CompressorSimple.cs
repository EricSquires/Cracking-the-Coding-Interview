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
                    if (i != 0)
                    {
                        ret.Append(currentChar);
                        if (count > 1)
                        {
                            ret.Append(count);
                        }
                    }

                    currentChar = txt[i];
                    count = 0;
                }
            }

            ret.Append(currentChar);
            if (count > 1)
            {
                ret.Append(count);
            }

            return ret.ToString();
        }
    }
}
