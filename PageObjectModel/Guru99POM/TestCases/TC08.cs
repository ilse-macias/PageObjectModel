using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class TC08 : TestBase
    {
        [Test, Description("Verify you are able to change or reorder previously added product.")]
        public void ChangePreviousProduct()
        {
            MenuPOM menu = new MenuPOM(driver);
            AccountSubOptions account = menu.ClickOnAccountOption();
            MyAccountPOM myAccount = account.ClickOnMyAccount();
            MyDashboardPOM dashboard = myAccount.LoginAccount(Information.EMAIL, Information.PASSWORD);
            MyOrdersPOM myOrders = dashboard.ClickOnMyOrders();
            AddToCartPOM shoppingCart = myOrders.ClickOnReorder();
            shoppingCart.EditQuantity(10);
            shoppingCart.ClickOnUpdateButton();
            CheckoutWithFillsPOM checkout = shoppingCart.ClickOnProceedToCheckoutButtonFill();
            checkout.ClickOnBillingButton();
            //checkout.ClickOnBillingButton();
            //checkout.ClickOnShippingInfo();
        }
    }
}
