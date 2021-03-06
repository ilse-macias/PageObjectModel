﻿using NUnit.Framework;

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
            shoppingCart.ApplyDiscountCodes("GURU50");
            shoppingCart.VerifyDiscount();
        }
    }
}
