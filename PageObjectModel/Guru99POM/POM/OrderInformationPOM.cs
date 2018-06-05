using OpenQA.Selenium;
using System;
using System.Threading;


namespace Guru99POM
{
    public class OrderInformationPOM : TestBase
    {
        /*Constructor*/
        public OrderInformationPOM(IWebDriver Driver) => driver = Driver;
       
        /*Controllers*/
        private IWebElement printOrderLink =>
            Properties.driver.FindElement(By.LinkText("Print Order"));

        TakeScreenshot screenshot = new TakeScreenshot();

        /*Method*/

        /// <summary>
        /// Click on 'Print Order' link.
        /// </summary>
        public void ClickOnPrintOrderLink()
        {
            printOrderLink.Click();
           // screenshot.SaveScreenshot("print");
            Thread.Sleep(Constants.TIMER_SECONDS);
        }

        public void ClickOnSaveButtonPdf()
        {
            IWebElement saveButton =
                Properties.driver.FindElement(By.XPath("//button[@class='print default']"));

            saveButton.Click();
            saveButton.SendKeys(@"C:\Users\Leonime\Desktop\PDF\");
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("PDF Downloaded!");
        }
    }
}
