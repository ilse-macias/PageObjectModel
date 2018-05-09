using NUnit.Framework;

namespace Guru99POM.TestCases
{
    class TC03 : TestBase
    {
        [Test, Description("3. Verify that you can't add more product in cart than the product available in store.")]
        public void ErrorVerification()
        {
            HomePagePOM homePage = new HomePagePOM(driver);

            MobilePOM mobile = homePage.ClickOnMobileLink();

            AddToCartPOM cart = mobile.AddToCartMobile();
            cart.AddQuantity();
            cart.ClickOnUpdateButton();
            cart.VerifyErrorMessage();

            cart.ClickOnEmptyCart();
        }
    }
}
