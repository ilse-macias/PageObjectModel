using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    class AddToComparePOM : TestBase 
    {
        /*Constructor*/
        public AddToComparePOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement compareButton =
            Properties.driver.FindElement(By.XPath("//button[@title='Compare']"));
    }
}
