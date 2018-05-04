using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Guru99POM
{
    public class TC01 : TestBase
    {     
        [Test, Description("1. Verify item in Mobile List page can be sorted by 'Name'.")]
        public void MobilePageSortByName()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);
            homePage.HomePageTitle(); //Compare title.

            MobilePOM mobile = homePage.ClickOnMobileLink();                     
            mobile.SelectSort();
        }

        [Test, Description("2. Verify that cost of product in list page and details page are equal.")]
        public void VerifyCostOfProducts()
        {
            //  MobilePageSortByName();
            HomePagePOM homePage = new HomePagePOM(Properties.driver);

            MobilePOM mobile = homePage.ClickOnMobileLink();
            mobile.CostSonyXperiaMobile();

            MobileDetailsPOM mobileDetails = mobile.SeeDetailsOfMobileProduct();
            mobileDetails.SonyXperiaDetails();
        }

        [Test, Description("3. Verify that you can't add more product in cart than the product available in store.")]
        public void ErrorVerification()
        {
            HomePagePOM homePage = new HomePagePOM(driver);

            MobilePOM mobile = homePage.ClickOnMobileLink();

            AddToCartPOM cart = mobile.AddToCartMobile();
            cart.AddQuantityAndUpdate();
            cart.VerifyErrorMessage();

            cart.ClickOnEmptyCart();
        }
    }
}
