using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WD
{
    [TestFixture]
    public class WDTest
    {
        [Test]
        public void oneCanOpenGoogle()
        {
            IWebDriver google = new ChromeDriver();
            google.Navigate().GoToUrl("http://github.com");

            IWebElement buttonSearch = google.FindElement(By.XPath("//a[text()='Sign in']"));
            buttonSearch.Click();

            IWebElement loginSearch = google.FindElement(By.Name("login"));
            loginSearch.SendKeys("testautomationuser");

            IWebElement passwordSearch = google.FindElement(By.Name("password"));
            passwordSearch.SendKeys("Time4Death!");

            IWebElement button = google.FindElement(By.XPath("//input[@value='Sign in']"));
            button.Click();

        }
    }
}
