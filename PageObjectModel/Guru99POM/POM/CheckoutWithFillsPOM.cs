using OpenQA.Selenium;
using System;
using System.Threading;

namespace Guru99POM
{
    public class CheckoutWithFillsPOM : TestBase
    {
        /*constructor*/
        public CheckoutWithFillsPOM(IWebDriver Driver) => driver = Driver;



        /*Methods*/
        public void ClickOnBillingButton()
        {
            IWebElement BillingButton =
             Properties.driver.FindElement(By.XPath("//*[@id='billing-buttons-container']/button"));

            try
            {
                BillingButton.Click();

                Console.WriteLine("User clicks on Billing button");
                logger.Info("User clicks on Billing button");
            }

            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info(ex.Message);
            }
        }

        public void ClickOnShippingInfo()
        {
            IWebElement ShippingButton =
                Properties.driver.FindElement(By.XPath("//*[@id='shipping-buttons-container']/button"));

            try
            {
                Thread.Sleep(Constants.TIMER_SECONDS);
                ShippingButton.Click();

                Console.WriteLine("User clicks on 'Continue' button.");
                logger.Info("User clicks on 'continue' button");
            }

            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ClickOnShippingMethod()
        {
            IWebElement shippingMethod =
                Properties.driver.FindElement(By.XPath("//*[@id='shipping-method-buttons-container']/button"));

            Thread.Sleep(Constants.TIMER_SECONDS);
            shippingMethod.Click();

            Console.WriteLine("User has clicked on 'Continue' button of 'Shipping Method' section.");
            logger.Info("User has clicked on 'Continue' button of 'Shipping Method' section.");
        }

        public void ClickOnPaymentInformation()
        {
            IWebElement radioButton =
                Properties.driver.FindElement(By.XPath("//input[@title='Check / Money order']"));
            IWebElement paymentButton =
                Properties.driver.FindElement(By.XPath("//*[@id='payment-buttons-container']/button"));
            try
            {
                radioButton.Click();
                Console.WriteLine("Radio Button selected");

                paymentButton.Click();
            }

            catch(InvalidElementStateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ClickOnPlaceOrderButton()
        {
            IWebElement placeOrderButton =
                Properties.driver.FindElement(By.XPath("//button[@class='button btn-checkout']"));

            placeOrderButton.Click();
        }
    }
}
