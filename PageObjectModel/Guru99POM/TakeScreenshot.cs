using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99POM
{
    public class TakeScreenshot : TestBase
    {
        public void SaveScreenshot(string testCaseName)
        {
            Screenshot ss = ((ITakesScreenshot)Properties.driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\" + testCaseName + ".png", ScreenshotImageFormat.Png);
            
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine("Screenshot captured.");
            logger.Info("Screenshot captured.");
        }
      
    }
}
