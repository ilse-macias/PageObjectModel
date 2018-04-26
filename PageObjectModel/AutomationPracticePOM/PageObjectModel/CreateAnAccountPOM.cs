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

        /**Constructor**/
        public CreateAnAccountPOM(IWebDriver Driver) => driver = Driver;

        /**Controllers**/
        //Radio Button.
        private IWebElement titleRadioButton => driver.FindElement(By.Id("id_gender2"));

        //Text Boxes.
        private IWebElement firstNameField => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement lastNameField => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement passwordField => driver.FindElement(By.Id("passwd"));

        //Drop-Down List.
        private IWebElement dayDropDown => driver.FindElement(By.Id("days"));
        private IWebElement monthDropDown => driver.FindElement(By.Id("months"));
        private IWebElement yearDropDown => driver.FindElement(By.Id("years"));

        //Check boxes.
        private IWebElement newslettersCheck => driver.FindElement(By.Id("newsletter"));

        /**Methods**/
        public void PersonalInformation(string firstName, string lastName, string password)
        {
            try
            {
                titleRadioButton.Click();
                firstNameField.SendKeys(firstName);
                lastNameField.SendKeys(lastName);
                passwordField.SendKeys(password);
            }

            catch(NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        //Select option.
        public void SelectList(string day, string month, string year)
        {
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByValue(day);

            SelectElement monthOption = new SelectElement(monthDropDown);
            monthOption.SelectByValue(month);

            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue(year);

            newslettersCheck.Click();
        }
    }
}
