using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class TC07 : TestBase
    {
        [Test]
        public void PrintPdf()
        {
            MenuPOM menu = new MenuPOM(driver);
            AccountSubOptions account = menu.ClickOnAccountOption();
            MyAccountPOM myAccount = account.ClickOnMyAccount();
            MyDashboardPOM dashboard = myAccount.LoginAccount(Information.EMAIL, Information.PASSWORD);
            MyOrdersPOM myOrders = dashboard.ClickOnMyOrders();
            OrderInformationPOM orderInformation = myOrders.ViewOrders();
            orderInformation.ClickOnPrintOrderLink();
            orderInformation.ClickOnSaveButtonPdf();
        }
    }
}
