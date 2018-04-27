using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    class ContactUsPOM : TestBase
    {
        private IWebDriver driver;

        /*Constructor*/
        public ContactUsPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IWebElement subjectHeadingDropDown => driver.FindElement(By.Id("id_contact"));
        private IWebElement emailAddressField => driver.FindElement(By.Name("from"));
        private IWebElement orderReferenceField => driver.FindElement(By.Name("id_order"));
        private IWebElement attachFileField => driver.FindElement(By.Id("fileUpload"));
        private IWebElement sendButton => driver.FindElement(By.Id("submitMessage"));

        /*Methods*/
        public void SendAMessage(string option, string email, string order)
        {
            SelectElement subjectOption = new SelectElement(subjectHeadingDropDown);
            subjectOption.SelectByValue(option);

            emailAddressField.SendKeys(email);
            logger.Info($"Email: {Constants.EMAIL}");

            orderReferenceField.SendKeys(order);
            attachFileField.SendKeys(Constants.UPLOAD_FILE);
            logger.Info($"Upload {attachFileField.Text}");

            sendButton.Click();
        }
    }
}
