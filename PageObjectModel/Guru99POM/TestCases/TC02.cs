using NUnit.Framework;

namespace Guru99POM.TestCases
{
    class TC02 : TestBase
    {
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
    }
}
