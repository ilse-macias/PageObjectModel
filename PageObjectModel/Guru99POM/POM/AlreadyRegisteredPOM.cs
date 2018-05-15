using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class AlreadyRegisteredPOM : TestBase
    {
        /*Constructor*/
        public AlreadyRegisteredPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement emailAddressField =
            Properties.driver.FindElement(By.Id("email"));
        private IWebElement passwordField => driver.FindElement(By.Id("pass"));
        private IWebElement loginButton => driver.FindElement(By.Id("send2"));

        /*Methods*/

        public void LoginAccount(string email, string password)
        {
            emailAddressField.SendKeys(email);
            Thread.Sleep(Constants.TIMER_SECONDS);

            passwordField.SendKeys(password);
            Thread.Sleep(Constants.TIMER_SECONDS);

            loginButton.Click();
            Console.WriteLine("Login button has been clicked");

        }
    }
}
