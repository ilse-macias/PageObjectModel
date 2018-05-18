using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class TC09 : TestBase
    {
        [Test, Description("Verify Discount Coupon works correctly")]
        public void DiscountCoupon()
        {
            HomePagePOM homePage = new HomePagePOM(Properties.driver);

            MobilePOM mobile = homePage.ClickOnMobileLink();
            AddToCartPOM shoppingCart = mobile.AddToCartMobile();
            shoppingCart.TypeDiscountCodes("GURU50");
        }
    }
}
