using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class TC05 : TestBase
    {
        [Test, Description("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void CreateAccount()
        {
            MenuPOM menu = new MenuPOM(driver);
            AccountSubOptions accountSubOptions = menu.ClickOnAccountOption();
            MyAccountPOM myAccount = accountSubOptions.ClickOnMyAccount();

            //CreateAnAccountPOM createAccount = myAccount.CreateAnAccount();
            //createAccount.FillTheFields("ABC", "DEF", "abcd@de.com", "123456");
            //MyDashboardPOM myDashboard = createAccount.ClickOnRegisterButton();
            //myDashboard.VerifyRegistrationIsDone();

            MyDashboardPOM myDashboard = myAccount.LoginAccount("abcd@de.com", "123456");
            TelevisionPOM television =  myDashboard.ClickOnTvLink(); //try with MenuPOM
            MyWishlistPOM myWishlist = television.AddToWishList();
            ShareWishlistPOM shareWishlists = myWishlist.ClickOnShareWishlist();
            shareWishlists.ShareWishlist("test@mail.com", "Hello world!");

        }
    }
}
