using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    class TakeAScreen : TestBase
    {
        public void SaveScreenshot(string testCaseName)
        {
            Screenshot ss = ((ITakesScreenshot)Properties.driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\" + testCaseName + ".png", ScreenshotImageFormat.Png);

            Console.WriteLine("Screenshot captured.");
            logger.Info("Screenshot captured.");
        }
      
    }
}
