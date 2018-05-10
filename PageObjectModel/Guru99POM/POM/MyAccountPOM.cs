using OpenQA.Selenium;
using System;
using System.Threading;

namespace Guru99POM
{
    public class MyAccountPOM : TestBase
    {
        /*Constructor*/
        public MyAccountPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement createAnAccountButton =
            Properties.driver.FindElement(By.XPath("//a[@title='Create an Account']"));

        TakeScreenshot saveScreen = new TakeScreenshot();

        /*Method*/

        /// <summary>
        /// Click on "Create An Account" button
        /// It'll redirect to "Create An Account" page.
        /// </summary>
        public CreateAnAccountPOM CreateAnAccount()
        {
            createAnAccountButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);

            saveScreen.SaveScreenshot("img_010");
            Console.WriteLine("Screenshot captured.");
            logger.Info("Screenshot captured.");

            return new CreateAnAccountPOM(driver);
        }
    }
}
