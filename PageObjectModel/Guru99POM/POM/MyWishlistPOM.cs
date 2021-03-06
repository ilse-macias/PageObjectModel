﻿using OpenQA.Selenium;
using System;
using System.Threading;

namespace Guru99POM
{
    public class MyWishlistPOM : TestBase
    {
        /*Constructor*/
        public MyWishlistPOM(IWebDriver Driver) => driver = Driver;

        /*Controller*/
        private IWebElement shareWishlistButton =
            Properties.driver.FindElement(By.XPath("//button[@name='save_and_share']"));
        //Properties.driver.FindElement(By.ClassName("button btn-share"));

        TakeScreenshot screen = new TakeScreenshot();

        /*Method*/
        public ShareWishlistPOM ClickOnShareWishlist()
        {
            //IWebElement shareWishlistButton =
            //    Properties.driver.FindElement(By.XPath("//button[@class='button btn-share']"));

            Console.WriteLine("clicked on ShareList");

            try
            {
                shareWishlistButton.Click();
                //Thread.Sleep(Constants.TIMER_SECONDS);

                screen.SaveScreenshot("img001");

                Console.WriteLine("Share Wishlist button has been clicked.");
                logger.Info("Share Wishlist button has been clicked.");
            }

            catch (StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new ShareWishlistPOM(driver);
        }
    }
}
