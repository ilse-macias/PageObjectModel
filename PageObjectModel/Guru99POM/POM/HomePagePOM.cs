﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    class HomePagePOM : TestBase
    {
        /*Constructor*/
        public HomePagePOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/     
        private IWebElement mobileLink = Properties.driver.FindElement(By.LinkText(Constants.MOBILE));
        private IWebElement tvLink = Properties.driver.FindElement(By.LinkText(Constants.TV));
        
        private string actualTitle = Properties.driver.FindElement(By.CssSelector("h2")).Text;

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

                TakeAScreen takeScreen = new TakeAScreen();
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

        public void ClickOnTvLink()
        {
            tvLink.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);
        }
    }
}
