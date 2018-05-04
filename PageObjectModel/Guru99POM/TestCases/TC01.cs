using NUnit.Framework;

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
    }
}
