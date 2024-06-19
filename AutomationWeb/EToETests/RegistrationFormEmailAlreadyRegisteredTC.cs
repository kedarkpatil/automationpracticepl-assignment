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
    public class RegistrationFormEmailAlreadyRegisteredTC
    {
        private readonly IWebDriver _driver;
        private RegistrationPage _registration;
        private HomePage _homepage;
        //Data Driven Framework using Page objects
        private const string UserEmail = RegistrationData.UserEmail;
        private const string firstnamefusr = RegistrationData.FirstName;
        private const string lastnameusr = RegistrationData.LastName;
        private const string UserPass = RegistrationData.UserPassword;
        public RegistrationFormEmailAlreadyRegisteredTC()
        {
            _driver = new ChromeDriver();
            _registration = new RegistrationPage(_driver);
            _homepage = new HomePage(_driver);
        }
        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://www.automationpractice.pl/");
            _driver.Manage().Window.Maximize();
            // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            // WebDriverWait wait = new WebDriverWait();//
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.LinkText("New Customer")));
            _registration.ClickOnSignIn();
            _registration.EmailTypeMethod(UserEmail);
            _registration.ClickOnCreateAccount();
        }
        //Independent test  for verification of already registered email with account creation
        [Test]
        public void TC021_VerifyAccountCreationWithAllMandatoryFields()
        {
            _registration.FnameTypeMethod(firstnamefusr);
            _registration.LnameTypeMethod(lastnameusr);
            _registration.PwdTypeMethod(UserPass);
            _registration.ClickOnRegister();
            /*TimeSpan sleepDurati = TimeSpan.FromSeconds(6);
            Thread.Sleep(sleepDurati);*/
            _registration.AssertMyAccount();
            _registration.AssertAccountHasBeenCreated();
            //_homepage.HomeLinkClick();
            _homepage.SignOutClick();
            /*TimeSpan slep = TimeSpan.FromSeconds(3);
            Thread.Sleep(slep);*/
            _registration.ClickOnSignIn();
            _registration.EmailTypeMethod(UserEmail);
            _registration.AlertCreateAccount();
        }
        [TearDown]
        public void closeBrowser()//For clean up session
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
