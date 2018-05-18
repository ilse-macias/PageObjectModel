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

        private IWebElement emailAddressField =
            Properties.driver.FindElement(By.Id("email"));
        private IWebElement passwordField =
            Properties.driver.FindElement(By.Id("pass"));
        private IWebElement loginButton =
            Properties.driver.FindElement(By.Id("send2"));

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

        /// <summary>
        /// Login with the credentials
        /// It'll redirect to "My Dashboard" Page.
        /// </summary>
        
        public MyDashboardPOM LoginAccount(string email, string password)
        {
            emailAddressField.SendKeys(email);
            Thread.Sleep(Constants.TIMER_SECONDS);

            passwordField.SendKeys(password);
            Thread.Sleep(Constants.TIMER_SECONDS);

            loginButton.Click();
            Console.WriteLine("Login button has been clicked");

            return new MyDashboardPOM(driver);
        }
    }
}
