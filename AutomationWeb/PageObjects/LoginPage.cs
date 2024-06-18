using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AutomationWeb.PageObjects;
using AutomationWeb.TestData;
using SeleniumExtras.WaitHelpers;
//using DotNetSeleniumExtras.WaitHelpers;
namespace AutomationWeb.PageObjects
{
    class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        By buttonSignIn = By.CssSelector(".header_user_info");
        By inputEmail = By.CssSelector("#email");
        By inputPassword = By.CssSelector("#passwd");
        By buttonSignInUser = By.CssSelector("#SubmitLogin");
        public void LoginUser(string userName, string userPassword)
        {
            _driver.FindElement(buttonSignIn).Click();
            TimeSpan sleepDuration = TimeSpan.FromSeconds(4); //Thread sleep method is used because since SeleniumExtras.WaitHelpers not supported for 4.7.2 Project
            Thread.Sleep(sleepDuration);
            _driver.FindElement(inputEmail).SendKeys(userName);
            _driver.FindElement(inputPassword).SendKeys(userPassword);
            _driver.FindElement(buttonSignInUser).Click();
            TimeSpan sleepDuration1 = TimeSpan.FromSeconds(4); //Thread sleep method is used because since SeleniumExtras.WaitHelpers not supported for 4.7.2 Project
            Thread.Sleep(sleepDuration1);
        }
    }
}