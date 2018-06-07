using NUnit.Framework;

namespace Guru99POM
{
    public class TC04 : TestBase
    {
        [Test, Description("4. Verify that you are able to compare two products.")]
        public void CompareTwoProducts()
        {
            HomePagePOM homePage = new HomePagePOM(driver);

            MobilePOM mobile = homePage.ClickOnMobileLink();

            AddToComparePOM addToCompare = mobile.CompareProducts();
            addToCompare.CompareButton();
            addToCompare.PopUpWindows();
        }
    }
}
