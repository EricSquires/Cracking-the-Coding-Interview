﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    public class URLRealWorld : IURLifier
    {
        public string URLify(string txt)
        {
            return txt.Replace(" ", "%20");
        }
    }
}
