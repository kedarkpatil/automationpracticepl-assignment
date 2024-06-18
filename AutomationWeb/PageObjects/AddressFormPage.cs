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
    class AddressFormPage
    {
        private readonly IWebDriver _driver;

        public AddressFormPage(IWebDriver driver)
        {
            _driver = driver;
        }


        By Saveaddrformbtn = By.CssSelector("#submitAddress");
        public void SaveaddrbtnClick()
        {

            _driver.FindElement(Saveaddrformbtn).Click();
        }



    }
}



