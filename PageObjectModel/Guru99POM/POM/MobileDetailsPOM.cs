using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    class MobileDetailsPOM : TestBase
    {
        /*Constructor*/
        public MobileDetailsPOM(IWebDriver Driver) => driver = Driver;

        /*Controller*/
        private string priceMobileProductsDetails =
           Properties.driver.FindElement(By.Id("product-price-1"))
           .Text;

        /*Methods*/
        /// <summary>
        /// Click on Sony Xperia and read the cost of details.
        /// </summary>
        public void SonyXperiaDetails()
        {
            try
            {
                Assert.AreEqual("$100.00", priceMobileProductsDetails);
                Console.WriteLine("The cost of Sony Xperia (details) is: " + priceMobileProductsDetails);
                logger.Info($"The cost of Sony Xperia (details) is: {priceMobileProductsDetails}");
                Thread.Sleep(Constants.TIMER_SECONDS);

                OpenQA.Selenium.Screenshot ss = ((ITakesScreenshot)Properties.driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\img02.png", ScreenshotImageFormat.Png);
                Console.WriteLine("Screenshot captured.");
                logger.Info("Screenshot captured.");
            }

            catch (StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info($"{ex.Message}");
            }
        }

    }
}
