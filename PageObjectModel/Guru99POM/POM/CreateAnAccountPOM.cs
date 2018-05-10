using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class CreateAnAccountPOM : TestBase
    {
        /*Constructor*/
        public CreateAnAccountPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement firstNameField =
            Properties.driver.FindElement(By.Id("firstname"));
        private IWebElement lastNameField =
            Properties.driver.FindElement(By.Id("lastname"));
        private IWebElement emailAddressField =
            Properties.driver.FindElement(By.Id("email_address"));
        private IWebElement passwordField = 
            Properties.driver.FindElement(By.Id("password"));
        private IWebElement confirmPasswordField =
            Properties.driver.FindElement(By.Id("confirmation"));

        private IWebElement registerButton =
            Properties.driver.FindElement(By.XPath("//button[@title='Register']"));

        /*Method*/
        /// <summary>
        /// Fill all fields required.
        /// </summary>
        public void FillTheFields(string firstName, string lastName, string email, string password)
        {
            firstNameField.SendKeys(firstName);
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("First Name: " + firstName);
            logger.Info($"First Name: {firstName}");

            lastNameField.SendKeys(lastName);
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("Last Name: " + lastName);
            logger.Info($"Last Name: {lastName}");

            emailAddressField.SendKeys(email);
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("Password: " + email);
            logger.Info($"Password: {email}");

            passwordField.SendKeys(password);
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("Password: " + password);
            logger.Info($"Password: {password}");

            confirmPasswordField.SendKeys(password);
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("Confirm Password: " + password);
            logger.Info($"Confirm Password: {password}");
        }

        /// <summary>
        /// Click on "Registration" button.
        /// It will redirect to "My Dashboard" page.
        public MyDashboardPOM ClickOnRegisterButton()
        {
            registerButton.Click();
            Thread.Sleep(Constants.TIMER_SECONDS);
            Console.WriteLine("Button clicked!");
            logger.Info("Button clicked!");

            return new MyDashboardPOM(driver);
        }
    }
}
