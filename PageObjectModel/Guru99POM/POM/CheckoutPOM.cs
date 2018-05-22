using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class CheckoutPOM : TestBase
    {
        /*Constructor*/
        public CheckoutPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement addressField =>
            Properties.driver.FindElement(By.Id("billing:street1"));
        private IWebElement cityField =>
            Properties.driver.FindElement(By.Id("billing:city"));
        private IWebElement stateField =>
            Properties.driver.FindElement(By.Id("billing:region_id"));
        private IWebElement zipField =>
            Properties.driver.FindElement(By.Id("billing:postcode"));
        private IWebElement countryField =>
            Properties.driver.FindElement(By.Id("billing:country_id"));
        private IWebElement telephoneField =>
            Properties.driver.FindElement(By.Id("billing:telephone"));
        private IWebElement continueButton =>
            Properties.driver.FindElement(By.XPath("//button[@title='Continue']"));

        TakeScreenshot screenshot = new TakeScreenshot();

        /*Methods*/
        /// <summary>
        /// Method to select an option drop-down list.
        /// </summary>
        public void SelectList(string state)
        {
            SelectElement stateDropDownList = new SelectElement(stateField);
            stateDropDownList.SelectByText(state);

            //SelectElement countryDropDownList = new SelectElement(countryField);
            //countryDropDownList.SelectByText("United States");
        }
        
        public void BillingInformationCheckout(string address, string city, int zip, int telephone)
        {
            addressField.Clear();
            addressField.SendKeys(address);
            Thread.Sleep(Constants.TIMER_SECONDS);

            cityField.Clear();
            cityField.SendKeys(city);
            Thread.Sleep(Constants.TIMER_SECONDS);

            zipField.Clear();
            zipField.SendKeys(Convert.ToString(zip));
            Thread.Sleep(Constants.TIMER_SECONDS);

            telephoneField.Clear();
            telephoneField.SendKeys(Convert.ToString(telephone));
            Thread.Sleep(Constants.TIMER_SECONDS);

            screenshot.SaveScreenshot("billing_info");
        }

        public void BillingInformationButton()
        {
            continueButton.Click();
            Console.WriteLine("Billing Information has been completed.");
            logger.Info("Billing Information has been completed.");
        }

        public void ShippingMethodCheckout()
        {
            IWebElement shippingMethodButton =
                Properties.driver.FindElement(By.XPath("//button[@class='button validation-passed']"));

            string flatRateElement =
                Properties.driver.FindElement(By.CssSelector("#checkout-shipping-method-load>dl>dd>ul>li>label>span"))
                .Text;
            string flatRate = "$20.00";

            Assert.AreEqual(flatRate, flatRateElement);
            Console.WriteLine("Flat Rate: " + flatRate);
            logger.Info($"Flat Rate: {flatRate}");

            screenshot.SaveScreenshot("shipping_method");

            shippingMethodButton.Click();
        }
    }
}
