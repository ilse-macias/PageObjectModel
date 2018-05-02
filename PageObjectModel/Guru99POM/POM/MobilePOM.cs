using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    class MobilePOM : TestBase
    {
       /*Constructor*/
        public MobilePOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement selectSort = Properties.driver.FindElement(By.CssSelector("select"));
        //(By.XPath("//select[@title='Sort By']"));

        /*Method*/
        /// <summary>
        /// Select 'SORT BY' drop-down as 'Name'.
        /// The products are sorted by Name.
        /// </summary>
        public void SelectSort()
        {
            SelectElement sortOption = new SelectElement(selectSort);
            sortOption.SelectByIndex(1);
            Console.WriteLine("Option selected is: " + sortOption);
            Thread.Sleep(Constants.TIMER_SECONDS);

            Screenshot ss = ((ITakesScreenshot)Properties.driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\img01.png", ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot captured.");
        }

        //Read the cost of Sony Xperia mobile.

    }
}
