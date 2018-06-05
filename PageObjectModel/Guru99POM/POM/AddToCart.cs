using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Guru99POM
{
    public class AddToCartPOM : TestBase
    {
        /*Constructor*/
        public AddToCartPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement quantityField =
            Properties.driver.FindElement(By.XPath("//input[@class='input-text qty']"));
        private IWebElement updateButton =
            Properties.driver.FindElement(By.XPath("//*[@title='Update']"));

        private IWebElement couponCode =
            Properties.driver.FindElement(By.Id("coupon_code"));
        private IWebElement applyLink =
            Properties.driver.FindElement(By.XPath("//button[@title='Apply']"));


        private IWebElement proceedToCheckOutButton =
            Properties.driver.FindElement(By.XPath("//li[@class='method-checkout-cart-methods-onepage-bottom']"));


        TakeScreenshot screen = new TakeScreenshot();

        /*Methods*/
        /// <summary>
        /// * Clear the field.
        /// * Type '1000' into text box.
        /// </summary>
        public void AddQuantity()
        {
            quantityField.Clear();
            quantityField.SendKeys(Convert.ToString(Constants.QTY_SHOPPING_CART));
        }

        /// <summary>
        /// * Click on "Update" button.
        /// </summary>
        public void ClickOnUpdateButton()
        {
            updateButton.Click();
          //  Thread.Sleep(Constants.TIMER_SECONDS);

            Console.WriteLine("Update button has been clicked.");
            logger.Info("Update button has been clicked.");
        }

        /// <summary>
        /// * Verify Error Message: "Some of the products cannot be ordered in requested quantity." 
        /// 
        /// I added the element into method, because it throws "StaleElementReferenceException" exception. That exception means the element is not newer, it's old; it can't detected.
        /// </summary>
        public void VerifyErrorMessage()
        {
			string errorMessage = 
				Properties.driver.FindElement(
					By.CssSelector("body>div>div>div.main-container.col1-layout>div>div>div>ul>li>ul>li>span"))
				.Text;
			string message = "Some of the products cannot be ordered in requested quantity.";
            
			Assert.AreEqual(message, errorMessage); 
            Console.WriteLine(message);
            logger.Info(message);
        }

        /// <summary>
        /// * Click on "Empty Cart" button.
        /// 
        /// I added the element into method, because it throws "StaleElementReferenceException" exception. That exception means the element is not newer, it's old; it can't detected.
        /// </summary>
        public void ClickOnEmptyCart()
        {
			IWebElement emptyCartLink =
			   Properties.driver.FindElement(By.Id("empty_cart_button"));

            try
            {
                emptyCartLink.Submit();

                string confirmMessage =
                    Properties.driver.FindElement(By.ClassName("page-title"))
                    .Text;
                string message = "SHOPPING CART";

                Assert.AreEqual(message, confirmMessage);
                Console.WriteLine(message);
                logger.Info(message);

                TakeScreenshot screenShot = new TakeScreenshot();
                screenShot.SaveScreenshot("img_02");
            }

			catch(StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        /// <summary>
        /// Apply Discount Code:
        /// Code: GURU50
        /// </summary>
        public void ApplyDiscountCodes(string code)
        {
            couponCode.SendKeys(code);
            Thread.Sleep(Constants.TIMER_SECONDS);

            applyLink.Click();
        }

        /// <summary>
        /// Verify the discount generated.
        /// </summary>
        public void VerifyDiscount()
        {
            string message = "Coupon code \"GURU50\" was applied.";

            string messageCoupon =
                Properties.driver.FindElement(By.ClassName("success-msg")).Text;

            Assert.AreEqual(message, messageCoupon);
            Console.WriteLine(message);

            screen.SaveScreenshot("coupon_02");
            Thread.Sleep(Constants.TIMER_SECONDS);
        }

        ///
        public CheckoutPOM ClickOnProceedToCheckOutButton()
        {
            proceedToCheckOutButton.Click();
            screen.SaveScreenshot("checkout");

            return new CheckoutPOM(driver);
        }

        public CheckoutWithFillsPOM ClickOnProceedToCheckoutButtonFill()
        {

            IWebElement proceedToCheckOutButton =
                Properties.driver.FindElement(By.XPath("//li[@class='method-checkout-cart-methods-onepage-bottom']"));

            proceedToCheckOutButton.Click();
            screen.SaveScreenshot("checkout fill info");

            return new CheckoutWithFillsPOM(driver);
        }

        public void EditQuantity(int quantity)
        {
            IWebElement editQuantity = 
                Properties.driver.FindElement(By.XPath("//input[@class='input-text qty']"));
            
            editQuantity.Click();
            editQuantity.Clear();
            editQuantity.SendKeys(Convert.ToString(quantity));
           // Thread.Sleep(Constants.TIMER_SECONDS);

            Console.WriteLine("User has edited the quantity");
            logger.Info("User has edited the quantity.");
        }
    }
}
