using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /*Methods*/
        public void CompareButton()
        {
            compareButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);

            Console.WriteLine("Button clicked!");
            logger.Info("Button clicked!");
        }

        public void PopUpWindows()
        {
            //Switch the windows.
            var windows = Properties.driver.WindowHandles;

            foreach(string handle in windows)
            {
                Console.WriteLine("Switching to windows: " + handle);
                Properties.driver.SwitchTo().Window(handle);
                Thread.Sleep(Constants.TIMER_SECONDS);
            }

            IWebElement compareTitle =
                Properties.driver.FindElement(By.CssSelector("body>div>div.page-title.title-buttons>h1"));

            Assert.AreEqual("COMPARE PRODUCTS", compareTitle.Text);
            Console.WriteLine("The title are equals: " + compareTitle.Text);
            logger.Info($"The title are equals: {compareTitle.Text}");
        }
    }
}
