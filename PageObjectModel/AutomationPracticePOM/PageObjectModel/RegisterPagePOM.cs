using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    class RegisterPagePOM : TestBase
    {
        private IWebDriver driver;

        //Constuctor 
        public RegisterPagePOM(IWebDriver Driver) => driver = Driver;
    }
}
