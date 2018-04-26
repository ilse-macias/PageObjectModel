using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    class CreateAnAccountPOM : TestBase
    {
        public IWebDriver driver;

        //Constructor
        public CreateAnAccountPOM(IWebDriver Driver) => driver = Driver;

        //Controllers.
        private IWebElement titleRadioButton => driver.FindElement(By.Id("id_gender2"));

        private IWebElement firstNameField => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement lastNameField => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement passwordField => driver.FindElement(By.Id("passwd"));


        private IWebElement dayDropDown => driver.FindElement(By.Id("days"));

        //Method
        public void PersonalInformation(string firstName, string lastname, string password)
        {
          //  titleRadioButton.Click();
            firstNameField.SendKeys(firstName);
        }

        public void SelectList(string day)
        {
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByValue(day);
        }
    }
}
