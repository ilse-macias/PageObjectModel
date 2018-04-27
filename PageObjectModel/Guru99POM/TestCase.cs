using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Guru99POM
{
    public class UnitTest1 : TestBase
    {
        [Test]
        public void Hewllo()
        {
            IWebElement search = driver.FindElement(By.Id("Search"));
            search.SendKeys("Hello");
            Thread.Sleep(5000);
        }
    }
}
