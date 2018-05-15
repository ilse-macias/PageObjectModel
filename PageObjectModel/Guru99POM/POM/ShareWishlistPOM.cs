using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class ShareWishlistPOM
    {
        /**/
        private IWebElement emailAddressField =
            Properties.driver.FindElement(By.Id("email_address"));
        private IWebElement messageField =
            Properties.driver.FindElement(By.Id("message"));
        private IWebElement shareWishlistButton =
            Properties.driver.FindElement(By.XPath("//button[@title='Share Wishlist']"));

        TakeScreenshot screen = new TakeScreenshot();

        public void ShareWishlist(string email, string message)
        {
            //Message: Your Wishlist has been shared.
            emailAddressField.SendKeys(email);
            Thread.Sleep(Constants.TIMER_SECONDS);

            messageField.SendKeys(message);
            Thread.Sleep(Constants.TIMER_SECONDS);

            shareWishlistButton.Click();

            screen.SaveScreenshot("img_001");
            
        }
    }
}
