using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM.TestCases
{
    
    public class TC06 : TestBase
    {
        [Test, Description("Verify user is able to purchase product using registered email id.")]
        public void Checkout()
        {
            MenuPOM menu = new MenuPOM(Properties.driver);
            AccountSubOptions accountLink = menu.ClickOnAccountOption();
            MyAccountPOM myAccountLink = accountLink.ClickOnMyAccount();
            myAccountLink.LoginAccount("tamail@mailinator.com", "123456");
            MobilePOM mobile = menu.ClickOnMobileLink();
            AddToCartPOM shoppingCart = mobile.AddToCartMobile();
            CheckoutPOM checkout = shoppingCart.ClickOnProceedToCheckOutButton();
            checkout.BillingInformationCheckout(Information.ADDRESS, Information.CITY, Information.ZIP, Information.TELEPHONE);
            checkout.SelectList(Information.STATE);
            checkout.BillingInformationButton();
            checkout.ShippingMethodButton();
            checkout.PaymentInformationMethod();
        }
       
    }
}
