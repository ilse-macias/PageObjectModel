using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class MenuPOM : TestBase
    {
        /*Constructor*/
        public MenuPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement AccountLink =>
            Properties.driver.FindElement(By.LinkText(Constants.ACCOUNT));

        private IWebElement mobileLink =>
            Properties.driver.FindElement(By.LinkText(Constants.MOBILE));
        private IWebElement tvLink =>
            Properties.driver.FindElement(By.LinkText(Constants.TV));
        //  Properties.driver.FindElement(By.XPath("//li[@class='level0 nav - 2 last']"));

        /*Methods*/
        /// <summary>
        /// Account > My Account.
        /// "My Account" Sub-option menu.
        /// </summary>
        public AccountSubOptions ClickOnAccountOption()
        {
            AccountLink.Click();
          //  Thread.Sleep(Constants.TIMER_SECONDS);

            Console.WriteLine("Button clicked!");
            logger.Info("Button clicked");

            return new AccountSubOptions(driver);
        }

        public MobilePOM ClickOnMobileLink()
        {
            mobileLink.Click();

            //Re-directs to the page.
            return new MobilePOM(driver);
        }

        /// <summary>
        /// Account option menu.
        /// </summary>
        //public MyAccountPOM ClickOnMyAccount()
        //{
        //    myAccountOption.Click();
        //    Console.WriteLine("Button clicked!");
        //    logger.Info("Button clicked");

        //    return new MyAccountPOM(driver);
        //}

        ///// <summary>
        ///// "Television" option menu.
        ///// </summary>
        //public TelevisionPOM ClickOnTvLink()
        //{
        //    IWebElement tvLink =
        //        Properties.driver.FindElement(By.LinkText(Constants.TV));

        //    try
        //    {
        //        tvLink.Submit();
        //        Console.WriteLine("TV link clicked.");
        //    }

        //    catch (NoSuchElementException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return new TelevisionPOM(driver);
        //}
    }
}
