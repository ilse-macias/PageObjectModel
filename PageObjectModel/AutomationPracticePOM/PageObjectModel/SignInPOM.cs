using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    class SignInPOM : TestBase
    {
        private IWebDriver driver;

        //Constructor
        public SignInPOM(IWebDriver Driver) => driver = Driver;

        //Controls
        private IWebElement emailAddressField => driver.FindElement(By.Id("email_create"));
        private IWebElement createAnAccountButton => driver.FindElement(By.Id("SubmitCreate"));

        private IWebElement emailAddressFieldRegister => driver.FindElement(By.Id("email"));
        private IWebElement passwordFieldRegister => driver.FindElement(By.Id("passwd"));
        private IWebElement signInButton => driver.FindElement(By.Id("SubmitLogin"));

        private IWebElement forgotYourPasswordLink => driver.FindElement(By.CssSelector("#login_form>div>p.lost_password.form-group>a"));

        //Methods.
        public CreateAnAccountPOM CreateAccount(string email)
        {
            emailAddressField.SendKeys(email);
            Console.WriteLine("Email: " + email);
            logger.Info($"Email: {email}");

            createAnAccountButton.Click();
            Console.WriteLine($"Clicked on {createAnAccountButton}");
            logger.Info("Clicked");

            return new CreateAnAccountPOM(driver);
        }

        public RegisterPagePOM AlreadyRegister(string email, string password)
        {
            emailAddressFieldRegister.SendKeys(email);
            Console.WriteLine("Email: " + email);
            logger.Info($"Email: {email}");

            passwordFieldRegister.SendKeys(password);
            Console.WriteLine($"Password: " + password);
            logger.Info($"Password: {password}");

            forgotYourPasswordLink.Submit();
            Console.WriteLine("Clicked");
            logger.Info("Clicked!");

            return new RegisterPagePOM(driver);
        }

        public ForgotPasswordPOM ClickOnForgotYourPassword()
        {
            forgotYourPasswordLink.Click();
            logger.Info("Clicked!");
            return new ForgotPasswordPOM(driver);
        }
    }
}
