﻿using NUnit.Framework;
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
        private IList<IWebElement> addToCartPosition 
            = Properties.driver.FindElements(By.XPath("//button[@class='button btn-cart']"));

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
            Thread.Sleep(Constants.TIMER_SECONDS);

            Screenshot ss = ((ITakesScreenshot)Properties.driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\img01.png", ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot captured.");
        }

        /// <summary>
        /// Read the cost of Sony Xperia mobile.
        /// </summary>
        public void CostSonyXperiaMobile()
        {
            Assert.AreEqual("$100.00", priceMobileProduct.Text);
            Console.WriteLine("The cost of Sony Xperia is: " + priceMobileProduct.Text);
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

    }
}
