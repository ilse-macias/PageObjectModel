using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM.POM
{
    class MobilePOM : TestBase
    {
       /*Constructor*/
        public MobilePOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement selectSort = driver.FindElement(By.XPath("//select[@title='Sort By']"));
    }
}
