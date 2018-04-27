using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NLog;
using OpenQA.Selenium.IE;

namespace AutomationPracticePOM
{
    [TestFixture]
    [Parallelizable]
    public class TestCases : TestBase
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

            CreateAnAccountPOM createAccount = signIn.CreateAccount(Constants.EMAIL);
            logger.Info($"Email: {Constants.EMAIL}");
            Thread.Sleep(Constants.TIME_SECONDS);

            createAccount.PersonalInformation("Diego", "Perez", Constants.PASS);
            createAccount.SelectList("2", "6", "2009");           
            Thread.Sleep(Constants.TIME_SECONDS);
        }

        [Test, Description("Register to the portal")]
        public void RegisterToPortal()
        {
            HomePagePOM home = new HomePagePOM(Properties.driver);
            SignInPOM signIn = home.ClickOnSignIn();
            RegisterPagePOM register = signIn.AlreadyRegister(Constants.EMAIL, Constants.PASS);

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
            forgotPassword.ForgotYourPassword(Constants.EMAIL);
            Thread.Sleep(Constants.TIME_SECONDS);
        }

        [Test, Description("Contact Us > Send a Message")]
        public void SendMessage()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);
            ContactUsPOM contactUs = homePage.ClickOnContactUs();
            contactUs.SendAMessage("2", Constants.EMAIL, "1234");
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
