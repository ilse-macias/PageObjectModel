using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class AccountSubOptions : TestBase
    {
        /*Constructor*/
        public AccountSubOptions(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement MyAccountOption = 
            Properties.driver.FindElement(By.LinkText(AccountConst.MY_ACCOUNT));

        /*Methods*/
        public MyAccountPOM ClickOnMyAccount()
        {
            MyAccountOption.Click();
            Console.WriteLine("Button clicked!");
            logger.Info("Button clicked");

            return new MyAccountPOM(driver);
        }
    }
}
