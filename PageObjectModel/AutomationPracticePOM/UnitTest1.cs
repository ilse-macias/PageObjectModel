using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NLog;

namespace AutomationPracticePOM
{
    public class UnitTest1 : TestBase
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            Properties.driver = new FirefoxDriver();
            Properties.driver.Manage().Cookies.DeleteAllCookies();
            Properties.driver.Navigate().GoToUrl(Constants.URL);
            logger.Info($"URL: {Constants.URL}");

            Properties.driver.Manage().Window.Maximize();
        }

       [Test, Description("Create a new account.")]
        public void CreateAccount()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);

            SignInPOM signIn = homePage.ClickOnSignIn();
            CreateAnAccountPOM createAccount = signIn.CreateAccount("automation@mailinator.com");
            createAccount.PersonalInformation("Diego", "Perez", "123456");
            createAccount.SelectList("2");

            Thread.Sleep(Constants.TIME_SECONDS);
        }

        [Test, Description("Register to the portal")]
        public void RegisterToPortal()
        {
            HomePagePOM home = new HomePagePOM(Properties.driver);
            SignInPOM signIn = home.ClickOnSignIn();
            RegisterPagePOM register = signIn.AlreadyRegister("automation@mailinator.com", "123456");

            Thread.Sleep(Constants.TIME_SECONDS);
        }

        [Test, Description("Forgot your password.")]
        public void ForgotPass()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);
            SignInPOM signIn = homePage.ClickOnSignIn();
         //   signIn.ClickOnForgotYourPassword();

            //Return (re-directs)
            ForgotPasswordPOM forgotPassword = signIn.ClickOnForgotYourPassword();
            forgotPassword.ForgotYourPassword("test@mail.com");
            Thread.Sleep(Constants.TIME_SECONDS);
        }

        [TearDown]
        public void TearDown()
        {
            Properties.driver.Close();
            logger.Info("Close");

            Properties.driver.Quit();
            logger.Info("Quit!");
        }
    }
}
