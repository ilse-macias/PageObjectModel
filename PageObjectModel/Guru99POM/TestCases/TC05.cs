using NUnit.Framework;

namespace Guru99POM
{
    public class TC05 : TestBase
    {
        [Test, Description("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void CreateAccountAndShareWishlist()
        {
            MenuPOM menu = new MenuPOM(driver);
            AccountSubOptions accountSubOptions = menu.ClickOnAccountOption();
            MyAccountPOM myAccount = accountSubOptions.ClickOnMyAccount();

            CreateAnAccountPOM createAccount = myAccount.CreateAnAccount();
            createAccount.FillTheFields(Information.FIRST_NAME, Information.LAST_NAME, Information.EMAIL_REGISTER, Information.PASSWORD_REGISTER);
            MyDashboardPOM myDashboard = createAccount.ClickOnRegisterButton();
            myDashboard.VerifyRegistrationIsDone();

           // MyDashboardPOM myDashboard = myAccount.LoginAccount(Information.EMAIL, Information.PASSWORD);
            TelevisionPOM television =  myDashboard.ClickOnTvLink(); //try with MenuPOM
            MyWishlistPOM myWishlist = television.AddToWishList();
            ShareWishlistPOM shareWishlists = myWishlist.ClickOnShareWishlist();
            shareWishlists.ShareWishlist(Information.EMAIL_LOGIN, "Hello world!");
        }

        [Test, Description("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void LoginAndShareWishlist()
        {
            MenuPOM menu = new MenuPOM(driver);
            AccountSubOptions accountSubOptions = menu.ClickOnAccountOption();
            MyAccountPOM myAccount = accountSubOptions.ClickOnMyAccount();
            MyDashboardPOM myDashboard = myAccount.LoginAccount(Information.EMAIL_LOGIN, Information.PASSWORD_LOGIN);
            TelevisionPOM television = myDashboard.ClickOnTvLink(); //try with MenuPOM
            MyWishlistPOM myWishlist = television.AddToWishList();
            ShareWishlistPOM shareWishlists = myWishlist.ClickOnShareWishlist();
            shareWishlists.ShareWishlist(Information.EMAIL_LOGIN, "Hello world!");
        }
    }
}
