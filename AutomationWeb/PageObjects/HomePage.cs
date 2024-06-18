using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using AutomationWeb.TestData;
using OpenQA.Selenium.Support.UI; //For Select class for dropdown values
//using DotNetSeleniumExtras.WaitHelpers;
namespace AutomationWeb.PageObjects
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        By HomeLinkBtn = By.XPath("//a[@class='home' and contains(@href,'www.automationpractice.pl')]");
        By SignOutBtn = By.XPath("//div[@class='header_user_info']//a[contains(text(),'Sign out')]");
        public void HomeLinkClick()
        {
            _driver.FindElement(HomeLinkBtn).Click();
        }
        public void SignOutClick()
        {
            _driver.FindElement(SignOutBtn).Click();
            TimeSpan slep = TimeSpan.FromSeconds(4);
            Thread.Sleep(slep);
        }
    }
}