﻿using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    enum Browsers
    {
        GoogleChrome,
        FireFox
    }


    class Properties
    {
        //Auto-Implemented properties.
        public static IWebDriver driver { get; set; }
      
    }
}
