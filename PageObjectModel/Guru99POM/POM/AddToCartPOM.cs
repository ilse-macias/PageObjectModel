using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    class AddToCartPOM : TestBase
    {
        /*Constructor*/
        public AddToCartPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement quantityField =
            Properties.driver.FindElement(By.XPath("//input[@class='input-text qty']"));
        private IWebElement updateButton =
            Properties.driver.FindElement(By.XPath("//*[@title='Update']"));

	    /*Methods*/
		/// <summary>
        /// * Type '1000' into text box.
        /// * Click on "Update" button.
        /// </summary>
		public void AddQuantityAndUpdate()
        {
            quantityField.Clear();
            quantityField.SendKeys(Convert.ToString(Constants.QTY_SHOPPING_CART));
            updateButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);
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

                TakeAScreen screenShot = new TakeAScreen();
                screenShot.SaveScreenshot("img_02");
            }

			catch(StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
