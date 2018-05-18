using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Guru99POM
{
    public class MyDashboardPOM : TestBase
    {
        /*Constructor*/
        public MyDashboardPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement dashboardTitle =
            Properties.driver.FindElement(By.ClassName("page-title"));
        private IWebElement tvLink =
           Properties.driver.FindElement(By.LinkText(Constants.TV));

        TakeScreenshot screenshot = new TakeScreenshot();

        /*Methods*/

        /// <summary>
        /// Verify if the registration is done.
        /// </summary>
        public void VerifyRegistrationIsDone()
        {
            IWebElement confirmationMessage =
                Properties.driver.FindElement(By.ClassName("success-msg"));

            string message = "Thank you for registering with Main Website Store.";
            Assert.AreEqual(message, confirmationMessage.Text);

            Console.WriteLine("Message are equals: " + message);
            logger.Info($"Message are equals: {message}");
            
            screenshot.SaveScreenshot("confirm_register");
        }

        /// <summary>
        /// Verify dashboard title.
        /// </summary>
        public void DashboardTitle()
        {
            string message = "MY DASHBOARD";
            Assert.AreEqual(message, dashboardTitle.Text);

            Console.WriteLine("Message are equal: " + message);
            logger.Info($"Message are equals: {message}");

            screenshot.SaveScreenshot("Dashboard Title");
        }

        /// <summary>
        /// "Television" option menu.
        /// </summary>
        public TelevisionPOM ClickOnTvLink()
        {
            try
            {
                Console.WriteLine(tvLink.Text);
                Thread.Sleep(Constants.TIMER_SECONDS);
                tvLink.Click();

                Thread.Sleep(Constants.TIMER_SECONDS);
                Console.WriteLine("TV link clicked.");
            }

            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new TelevisionPOM(driver);
        }
    }
}
