using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Guru99POM
{
    class MobilePOM : TestBase
    {
        /*Constructor*/
        public MobilePOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement selectSort =
            Properties.driver.FindElement(By.CssSelector("select"));

        private IWebElement priceMobileProduct =
            Properties.driver.FindElement(By.Id("product-price-1"));
        private IWebElement clickMobileProduct =
            Properties.driver.FindElement(By.CssSelector("#product-collection-image-1"));

        private IList<IWebElement> itemPosition =
            Properties.driver.FindElements(By.XPath("//li[@class='item last']"));
        private IList<IWebElement> addToCartPosition =
            Properties.driver.FindElements(By.XPath("//button[@class='button btn-cart']"));

        private IList<IWebElement> addToCompareLink =
            Properties.driver.FindElements(By.ClassName("link-compare"));

        /*Method*/
        /// <summary>
        /// Select 'SORT BY' drop-down as 'Name'.
        /// The products are sorted by Name.
        /// </summary>
        public void SelectSort()
        {
            SelectElement sortOption = new SelectElement(selectSort);
            sortOption.SelectByIndex(1);
            Console.WriteLine("Option selected is: " + sortOption);
            logger.Info($"Option selected is: {sortOption}");

            Thread.Sleep(Constants.TIMER_SECONDS);

            TakeAScreen screen = new TakeAScreen();
            screen.SaveScreenshot("img_001");
        }

        /// <summary>
        /// Read the cost of Sony Xperia mobile.
        /// </summary>
        public void CostSonyXperiaMobile()
        {
            Assert.AreEqual("$100.00", priceMobileProduct.Text);
            Console.WriteLine("The cost of Sony Xperia is: " + priceMobileProduct.Text);
            logger.Info($"The cost of Sony Xperia is: {priceMobileProduct.Text}");
        }

        /// <summary>
        /// Displays "Sony Xperia mobile" details page.
        /// </summary>
        public MobileDetailsPOM SeeDetailsOfMobileProduct()
        {
            clickMobileProduct.Click();

            //redirects to Deatails page.
            return new MobileDetailsPOM(driver);
        }

        /// <summary>
        /// Click on "ADD TO CART" button for SonyXperia.
        /// </summary>
        public AddToCartPOM AddToCartMobile()
        {
            int apuntador = 0;

            //Count the position of Sony Xperia.
            for (int j = 0; j <= itemPosition.Count; j++)
            {
                if (apuntador == j)
                {
                    //Click on "Add to cart" button of Sony Xperia.
                    for (int i = 0; i <= addToCartPosition.Count; i++)
                    {
                        if (i == j)
                        {
                            addToCartPosition[apuntador].Click();
                            Console.WriteLine("The mobile selected is: " + addToCartPosition[apuntador]);
                            logger.Info($"The mobile selected is: {addToCartPosition[apuntador]}");
                            Thread.Sleep(Constants.TIMER_SECONDS);
                        }
                    }
                }
            }
            return new AddToCartPOM(driver);
        }

        /// <summary>
        /// Compare two products.
        ///     Phone 1: Sony Xperia
        ///     Phone 2: iPhone
        /// </summary>
        public AddToComparePOM CompareProducts()
        {
            int productOne = 1;
            int productTwo = 0;

            for (int i = 0; i <= itemPosition.Count; i++)
            {
                //Product #1 and Product #2.
                if (i == productOne || productTwo == i)
                {
                    // Click on the product
                    for (int j = 0; j <= addToCompareLink.Count; j++)
                    {
                        if (j == productOne)
                        {
                            addToCompareLink[productOne].Click();
                            Thread.Sleep(Constants.TIMER_SECONDS);
                            Console.WriteLine("Product One: " + addToCompareLink[productOne].ToString());
                            logger.Info($"Product One: {addToCompareLink[productOne].ToString()}");
                        }

                        if (j == productTwo)
                        {
                            addToCompareLink[productTwo].Click();
                            Thread.Sleep(Constants.TIMER_SECONDS);

                            Console.WriteLine("Product Two: " + addToCompareLink[productTwo].ToString());
                            logger.Info($"Product Two: {addToCompareLink[productTwo].ToString()}");
                        }
                    }
                }
            }
            return new AddToComparePOM(driver);
        }
    }
}
