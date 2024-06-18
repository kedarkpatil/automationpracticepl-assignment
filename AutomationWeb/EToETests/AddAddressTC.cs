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
namespace AutomationWeb.EToETests
{
    [TestFixture]
    class AddAddressTC
    {
        private  IWebDriver _driver;
        private RegistrationPage _registration;
        private HomePage _homepage;
        private LoginPage _loginpage;
        private MyaccountPage _myaccpage;
        private AddressFormPage _addrformpage;
        private const string UserEmail = RegistrationData.UserEmail;
        private const string UserPass = RegistrationData.UserPassword;
        public AddAddressTC()
        {
            _driver = new ChromeDriver();
            _registration = new RegistrationPage(_driver);
            _homepage = new HomePage(_driver);
            _loginpage = new LoginPage(_driver);
            _myaccpage = new MyaccountPage(_driver);
            _addrformpage = new AddressFormPage(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://www.automationpractice.pl/");
            _driver.Manage().Window.Maximize();
            _loginpage.LoginUser(UserEmail, UserPass);
        }
        //Verification test for Address addition Form
        [Test]
        public void TC022_VerifyAccountCreationWithAllMandatoryFields()
        {
            _myaccpage.AddMyaddressLnkClick();
            TimeSpan sleepDuration = TimeSpan.FromSeconds(4);
            Thread.Sleep(sleepDuration);
            _addrformpage.SaveaddrbtnClick();
            TimeSpan sleepDuration1 = TimeSpan.FromSeconds(5);
            Thread.Sleep(sleepDuration1);
            _registration.AssertFiveErrorMessage();
            _homepage.SignOutClick();
        }
        [TearDown]
        public void closeBrowser()
        {
            _driver.Close();
        }
    }
}