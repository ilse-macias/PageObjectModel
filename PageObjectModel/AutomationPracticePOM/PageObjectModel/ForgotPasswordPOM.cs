using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    class ForgotPasswordPOM : TestBase
    {
        private IWebDriver driver;

        //Constructor
        public ForgotPasswordPOM(IWebDriver Driver) => driver = Driver;

        //Controller
        private IWebElement emailAddressField => driver.FindElement(By.Id("email"));
        private IWebElement retrievePasswordButton => driver.FindElement(By.CssSelector("#form_forgotpassword>fieldset>p>button>span"));

        private IWebElement backToLoginButton => driver.FindElement(By.CssSelector("#center_column>ul>li>a>span"));

        //Methods.
        public void ForgotYourPassword(string email)
        {
            emailAddressField.SendKeys(email);
            logger.Info($"Email: {email}");

            retrievePasswordButton.Submit();
            logger.Info("Clicked!");
        }
    }
}
