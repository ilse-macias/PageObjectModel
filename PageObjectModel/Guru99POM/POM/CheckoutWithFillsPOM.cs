using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class CheckoutWithFillsPOM : TestBase
    {
        /*constructor*/
        public CheckoutWithFillsPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement BillingButton =>
            Properties.driver.FindElement(By.Id("billing-buttons-container"));

        /*Methods*/
        public void ClickOnBillingButton()
        {
            BillingButton.Click();

        }

        public void ClickOnShippingInfo()
        {
            IWebElement ShippingButton = 
                Properties.driver.FindElement(By.Id("shipping-buttons-container"));

            ShippingButton.Click();
        }
    }
}
