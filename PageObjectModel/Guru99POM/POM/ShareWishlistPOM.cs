using OpenQA.Selenium;
using System.Threading;

namespace Guru99POM
{
    public class ShareWishlistPOM : TestBase
    {
        /*Constructor*/
        public ShareWishlistPOM(IWebDriver Driver) => driver = Driver;
        
        /*Controllers*/
        private IWebElement emailAddressField =
            Properties.driver.FindElement(By.Id("email_address"));
        private IWebElement messageField =
            Properties.driver.FindElement(By.Id("message"));
        private IWebElement shareWishlistButton =
            Properties.driver.FindElement(By.XPath("//button[@title='Share Wishlist']"));

        TakeScreenshot screen = new TakeScreenshot();

        /*Methods*/
        public void ShareWishlist(string email, string message)
        {
          //  Thread.Sleep(Constants.TIMER_SECONDS);

            //Message: Your Wishlist has been shared.
            emailAddressField.SendKeys(email);
            Thread.Sleep(Constants.TIMER_SECONDS);

            messageField.SendKeys(message);
            Thread.Sleep(Constants.TIMER_SECONDS);

            shareWishlistButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);

            screen.SaveScreenshot("img_001");
        }
    }
}
