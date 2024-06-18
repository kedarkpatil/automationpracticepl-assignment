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
    public class RegistrationFormTests
    {
        private readonly IWebDriver _driver;
        private RegistrationPage _registration;
        private const string firstname = RegistrationData.UserFirstNameValid;
        private const string lastname = RegistrationData.UserLastNameValid;
        private const string pasword = RegistrationData.UserPasswordValid;
        public RegistrationFormTests()
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
            Thread.Sleep(sleepDuration);
            _registration.EmailTypeMethod(RegistrationData.UserEmailValid);
            _registration.ClickOnCreateAccount();
        }
        //Tests for verification of registration form
        [Test]
        public void TC010_ValidationRegistForm()
        {
            _registration.ClickOnRegister();
            _registration.AssertThreeErrorMessage();
        }
        [Test]
        public void TC011_ValidationRegistFormWithFnameOnly()
        {
            _registration.FnameTypeMethod(firstname);
            _registration.ClickOnRegister();
            _registration.AssertTwoErrorMessage();
        }
        [Test]
        public void TC013_ValidationRegistFormWithPwd()
        {
            _registration.PwdTypeMethod(pasword);
            _registration.ClickOnRegister();
            _registration.AssertTwoErrorMessage();
        }
        [Test]
        public void TC015_ValidationEmailWithoutLastName()
        {
            _registration.FnameTypeMethod(firstname);
            _registration.PwdTypeMethod(pasword);
            _registration.ClickOnRegister();
            _registration.AssertOneErrorMessage();
        }
        [Test]
        public void TC017_ValidationWithInvaliddate()
        {
            _registration.ClickOnMr();
            _registration.FnameTypeMethod(firstname);
            _registration.LnameTypeMethod(lastname);
            _registration.PwdTypeMethod(pasword);
            _registration.DOBDaysSelectDropdown("31");
            _registration.DOBMonthSelectDropdown("2");
            _registration.DOBDaysSelectDropdown("2024");
            _registration.ClickOnNewsLetter();
            _registration.ClickOnRegister();
            _registration.AssertOneErrorMessage();
            _registration.AssertInvalidDateOfBirth();
        }
        [Test]
        public void TC020_VerifyAccountCreationWithAllMandatoryFields()
        {
            _registration.FnameTypeMethod(firstname);
            _registration.LnameTypeMethod(lastname);
            _registration.PwdTypeMethod(pasword);
            _registration.ClickOnRegister();
            _registration.AssertMyAccount();
            _registration.AssertAccountHasBeenCreated();
        }
        [Test]
        public void TC021_VerifyAccountCreationWithAllMandatoryFields()
        {
            _registration.AlertCreateAccount();
        }
        private string GetRandomEmail()
        {
            // implement your own email generator logic here  
            return "randomemail@example.com";
        }
        [TearDown]
        public void closeBrowser()
        {
            _driver.Close();
        }
    }
}