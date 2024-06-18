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
    class MyaccountPage
    {
        private readonly IWebDriver _driver;
        public MyaccountPage(IWebDriver driver)
        {
            _driver = driver;
        }
        //Links on page
        By AddMyFrstaddrLnk = By.XPath("//a[contains(@title,'Add my first address') and  contains(@href,'www.automationpractice.pl')]");
        By SignOutBtn = By.XPath("//div[@class='header_user_info']//a[contains(text(),'Sign out')]");
        public void AddMyaddressLnkClick()
        {
            _driver.FindElement(AddMyFrstaddrLnk).Click();
        }
        public void SignOutClick()
        {
            _driver.FindElement(SignOutBtn).Click();
        }
    }
}