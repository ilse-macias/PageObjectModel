using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void SetUp()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Manage().Cookies.DeleteAllCookies();
            Properties.driver.Navigate().GoToUrl(Constants.URL);
            logger.Info($"URL: {Constants.URL}");
            Properties.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Properties.driver.Close();
            Properties.driver.Quit();
        }
    }
}
