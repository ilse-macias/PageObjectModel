using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Guru99POM
{
    public class MyDashboardPOM : TestBase
    {
        /*Constructor*/
        public MyDashboardPOM(IWebDriver Driver) => driver = Driver;
        
        /*Controllers*/
        private IWebElement confirmationMessage =
            Properties.driver.FindElement(By.ClassName("success-msg"));

        TakeScreenshot screenshot = new TakeScreenshot();

        /*Methods*/

        /// <summary>
        /// Verify if the registration is done.
        /// </summary>
        public void VerifyRegistrationIsDone()
        {
            string message = "Thank you for registering with Main Website Store.";
            Assert.AreEqual(message, confirmationMessage.Text);

            Console.WriteLine("Message are equals: " + message);
            logger.Info($"Message are equals: {message}");
            
            screenshot.SaveScreenshot("confirm_register");
        }
    }
}
