using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class MyWishlistPOM : TestBase
    {
        /*Controller*/
        private IWebElement shareWishlistButton =
            Properties.driver.FindElement(By.Name("save_and_share"));

        public ShareWishlistPOM ClickOnShareWishlist()
        {
            shareWishlistButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);

            Console.WriteLine("Share Wishlist button has been clicked.");
            logger.Info("Share Wishlist button has been clicked.");

            return new ShareWishlistPOM();
        }
    }
}
