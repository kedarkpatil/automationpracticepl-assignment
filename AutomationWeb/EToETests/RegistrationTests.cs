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

namespace RegistrationTests
{
    [TestFixture]
    public class RegistrationTests
    {
        private readonly IWebDriver _driver;
        private RegistrationPage _registration;

        public RegistrationTests()
        {
            _driver = new ChromeDriver();
            _registration = new RegistrationPage(_driver);
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
            TimeSpan sleepDuration = TimeSpan.FromSeconds(3);
            Thread.Sleep(sleepDuration);//Thread sleep method is used because since SeleniumExtras.WaitHelpers not supported for 4.7.2 Project
        }

        //Tests for verification of Email field for account Creation
        [Test]
        public void TC001_ValidationEmailInputField()
        {
            const string validationEmailField = "Invalid email address.";
            _registration.ClickOnCreateAccount();
            var emailFieldValidation = _registration.getValText();
            Assert.That(emailFieldValidation, Does.Contain(validationEmailField));
        }

        [Test]
        public void TC003_ValidationEmailWithSpace()
        {
            const string emailWithSpace = RegistrationData.UserEmailWithSpace;
            const string validationEmailField = "Invalid email address.";
            _registration.EmailTypeMethod(emailWithSpace);
            _registration.ClickOnCreateAccount();
            var emailFieldValidation = _registration.getValText();
            Assert.That(emailFieldValidation, Does.Contain(validationEmailField));
        }

        [Test]
        public void TC005_ValidationEmailWithSemicolon()
        {
            const string emailWitSemicolon = RegistrationData.UserEmailWithSemicolon;
            const string validationEmailField = "Invalid email address.";
            _registration.EmailTypeMethod(emailWitSemicolon);
            _registration.ClickOnCreateAccount();
            var emailFieldValidation = _registration.getValText();
            Assert.That(emailFieldValidation, Does.Contain(validationEmailField));
        }

        [Test]
        public void TC006_ValidationEmailWithDotAtEnd()
        {
            const string emailWithDotAtEnd = RegistrationData.UserEmailWithDotAtEnd;
            const string validationEmailField = "Invalid email address.";
            _registration.EmailTypeMethod(emailWithDotAtEnd);
            _registration.ClickOnCreateAccount();
            var emailFieldValidation = _registration.getValText();
            Assert.That(emailFieldValidation, Does.Contain(validationEmailField));
        }


        [Test]
        public void TC008_ValidationCorrectEmail()
        {
            var emailRandom = GetRandomEmail();
            const string validationAuthentication = "Your personal information";
            _registration.EmailTypeMethod(emailRandom);
            _registration.ClickOnCreateAccount();
            var pageAuthentication = _registration.getAccountPersonalInfoText();
            Assert.That(pageAuthentication, Does.Contain(validationAuthentication));
        }

        private string GetRandomEmail()
        {
            // implement your own email generator logic here  for time being it is hard coded 
            return "randomemailid@example.com";
        }
        [TearDown]
        public void closeBrowser()//For clean up session
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
