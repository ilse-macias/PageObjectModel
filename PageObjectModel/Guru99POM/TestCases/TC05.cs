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
            createAccount.FillTheFields("ABC", "DEF", "abc@e.com", "123456");

            MyDashboardPOM myDashboard = createAccount.ClickOnRegisterButton();
            myDashboard.VerifyRegistrationIsDone();
            //menulo.ClickOnTvLink();

             

        }
    }
}
