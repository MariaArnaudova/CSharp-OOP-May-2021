﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseble
    {
        public string Browse(string url)
        {

            if (url.Any(x => char.IsDigit(x) ))
            {
                throw new ArgumentException("Invalid URL!");
            }
           return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.All(x => char.IsDigit(x) ))
            {
                return $"Calling... {number}";
               
            }

            throw new ArgumentException("Invalid number!");
        }
    
    }

}