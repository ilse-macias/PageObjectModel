using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace AutomationPracticePOM
{
    class HomePagePOM : TestBase
    {
        private IWebDriver driver;
      
        //Constructor
        public HomePagePOM(IWebDriver Driver) => driver = Driver;

        //Controllers
        private IWebElement signInLink => driver.FindElement(By.CssSelector("#header>div.nav>div>div>nav>div.header_user_info>a"));
        private IWebElement contactUsLink => driver.FindElement(By.Id("contact-link"));

        //Method
        public SignInPOM ClickOnSignIn()
        {
            signInLink.Click();
            Thread.Sleep(Constants.TIME_SECONDS);
            logger.Info("Clicked!");
            
            //return or re-direct a page.
            return new SignInPOM(driver);
        }

        public ContactUsPOM ClickOnContactUs()
        {
            contactUsLink.Click();
            Thread.Sleep(Constants.TIME_SECONDS);
            logger.Info($"Clicked {contactUsLink.Text}");

            return new ContactUsPOM(driver);
        }
    }
}
