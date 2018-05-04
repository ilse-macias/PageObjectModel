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
		public void AddQuantityAndUpdate()
        {
            //Type '1000' into text box.
            quantityField.Clear();
            quantityField.SendKeys(Convert.ToString(Constants.QTY_SHOPPING_CART));
            updateButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);
        }

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
