using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Guru99POM
{
    public class TestCase : TestBase
    {     
        [Test, Description("Verify item in Mobile List page can be sorted by 'Name'.")]
        public void MobilePageSortByName()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);
            homePage.HomePageTitle(); //Compare title.

            MobilePOM mobile = homePage.ClickOnMobileLink();                     
            mobile.SelectSort();
        }

        [Test, Description("Verify that cost of product in list page and details page are equal.")]
        public void Cost()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);
            MobilePOM mobile = homePage.ClickOnMobileLink();


        }
    }
}
