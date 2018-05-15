using OpenQA.Selenium;
using System.Collections.Generic;

namespace Guru99POM
{
    public class TelevisionPOM : TestBase
    {
        /*Constructor*/
        public TelevisionPOM(IWebDriver Driver) => driver = Driver;

        /*Controllers*/
        private IList<IWebElement> itemPosition =
            Properties.driver.FindElements(By.XPath("//li[@class='item last']"));
        private IList<IWebElement> addToWishlistLink =
            Properties.driver.FindElements(By.ClassName("link-wishlist"));

        /*Methods*/
        public MyWishlistPOM AddToWishList()
        {
            int position = 1;

            //Count the position of Item.
            for(int i = 0; i<= itemPosition.Count; i++)
            {
                //Si la posicion es igual al contador del if
                if(i == position)
                {
                    //Count the position of Link.
                    for (int j = 0; j <= addToWishlistLink.Count; j++)
                    {
                        addToWishlistLink[position].Click();
                    }                    
                }
            }
            //redirecciona a la pantalla de MyWishList
            return new MyWishlistPOM();
        }
    }
}
