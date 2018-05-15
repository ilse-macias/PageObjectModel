using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    class TC05 : TestBase
    {
        [Test, Description("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void CreateAccount()
        {
            MenuPOM menu = new MenuPOM(driver);
            AccountSubOptions accountSubOptions = menu.ClickOnAccountOption();
            MyAccountPOM myAccount = accountSubOptions.ClickOnMyAccount();
            CreateAnAccountPOM createAccount = myAccount.CreateAnAccount();
            createAccount.FillTheFields("ABC", "DEF", "abc@de.com", "123456");

            MyDashboardPOM myDashboard = createAccount.ClickOnRegisterButton();
            myDashboard.VerifyRegistrationIsDone();
            TelevisionPOM television = menu.ClickOnTvLink();
            MyWishlistPOM myWishlist = television.AddToWishList();
            ShareWishlistPOM shareWishlist = myWishlist.ClickOnShareWishlist();
            shareWishlist.ShareWishlist("test@mail.com", "Hello world!");

        }
    }
}
