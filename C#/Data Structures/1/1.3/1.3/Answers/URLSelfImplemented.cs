using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    public class URLSelfImplemented : IURLifier
    {
        public string URLify(string txt)
        {
            for(var i = txt.Length - 1; i >= 0; i--)
            {
                if(txt[i] == ' ')
                {
                    txt = txt.Remove(i, 1);
                    txt = txt.Insert(i, "%20");
                }
            }

            return txt;
        }
    }
}
