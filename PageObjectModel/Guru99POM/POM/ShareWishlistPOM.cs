using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM.POM
{
    class ShareWishlistPOM
    {
        /**/
        private IWebElement emailAddressField =
            Properties.driver.FindElement(By.Id("email_address"));
        private IWebElement messageField =
            Properties.driver.FindElement(By.Id("message"));
        private IWebElement shareWishlistButton =
            Properties.driver.FindElement(By.XPath("//button[@title='Share Wishlist']"));

        public void ShareWishlist(string email, string message)
        {
            //Message: Your Wishlist has been shared.
        }
    }
}
