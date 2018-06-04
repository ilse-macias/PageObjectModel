using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class MyOrdersPOM : TestBase
    {
        /*Constructor*/
        public MyOrdersPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement viewOrderLink =>
            Properties.driver.FindElement(By.LinkText("VIEW ORDER"));

        private IWebElement reorderLink =>
            Properties.driver.FindElement(By.LinkText("REORDER"));

        TakeScreenshot screenshot = new TakeScreenshot();

        /*Methods*/
        public OrderInformationPOM ViewOrders()
        {
            viewOrderLink.Click();
            screenshot.SaveScreenshot("TC_07");
            Thread.Sleep(Constants.TIMER_SECONDS);

            return new OrderInformationPOM(driver);
        }

        public AddToCartPOM ClickOnReorder()
        {
            reorderLink.Click();
            screenshot.SaveScreenshot("TC_08");
            Thread.Sleep(Constants.TIMER_SECONDS);

            return new AddToCartPOM(driver);
        }
    }
}
