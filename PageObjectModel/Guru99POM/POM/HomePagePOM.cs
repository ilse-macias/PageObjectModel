using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Guru99POM
{
    public class HomePagePOM : TestBase
    {
        /*Constructor*/
        public HomePagePOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/     
        private IWebElement mobileLink = Properties.driver.FindElement(By.LinkText(Constants.MOBILE));
        private IWebElement tvLink = Properties.driver.FindElement(By.LinkText(Constants.TV));
        
        private string actualTitle = Properties.driver.FindElement(By.CssSelector("h2")).Text;

        private IWebElement accountOption = 
            Properties.driver.FindElement(By.LinkText(Constants.ACCOUNT));
        
        /*Methods*/
        /// <summary>
        /// Scenario: Verify title of the page.
        /// Text 'THIS IS DEMO SITE' is shown in home page.
        ///     * Create a screenshot for evidence.
        ///     * Print in console and Nlog.
        /// </summary>
        public void HomePageTitle()
        {
            try
            {
                string expectedTitle = "THIS IS DEMO SITE FOR   ";
                Assert.AreEqual(expectedTitle, actualTitle);
                Console.WriteLine("Expected Title: " + expectedTitle);
                logger.Info($"Expected Title: {expectedTitle}");

                TakeScreenshot takeScreen = new TakeScreenshot();
                takeScreen.SaveScreenshot("img_01");
            }

            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
                logger.Info($"{e.Message}");
            }
        }

        public MobilePOM ClickOnMobileLink()
        {
            mobileLink.Click();
            //Thread.Sleep(Constants.TIMER_SECONDS);

            //Re-directs to the page.
            return new MobilePOM(driver);
        }

        //public TelevisionPOM ClickOnTvLink()
        //{
        //    tvLink.Click();
        //    Thread.Sleep(Constants.TIMER_SECONDS);

        //    return new TelevisionPOM(driver);
        //}

        //public MyAccountOptionsMenuPOM ClickOnAccountOption()
        //{
        //    accountOption.Click();
        //    Thread.Sleep(Constants.TIMER_SECONDS);

        //    return new MyAccountOptionsMenuPOM(driver);
        //}
    }
}
