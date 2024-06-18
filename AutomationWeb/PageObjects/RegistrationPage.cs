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
    public class RegistrationPage
    {
        private readonly IWebDriver _driver;
        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }
        // Elements
        By ButtonSignIn = By.CssSelector(".header_user_info");
        By ButtonCreateAccount = By.CssSelector("#SubmitCreate");
        By ButtonRegister = By.CssSelector("#submitAccount");
        By ValidationEmail = By.CssSelector("#create_account_error");
        //By ValidationEmail = By.XPath("//div[contains(@class, 'alert-danger')]//li[contains(text(),'Invalid email address.')]");
        By InputEmail = By.CssSelector("#email_create");
        // By ValidationPageAuthentication = By.CssSelector("#account-creation_form > div.account_creation > h3");
        By ValidationPageAuthentication = By.XPath("//div[@class='account_creation']//h3[text()='Your personal information']");
        By InputFirstName = By.CssSelector("#customer_firstname");
        By InputLastName = By.CssSelector("#customer_lastname");
        By InputPassword = By.CssSelector("#passwd");
        By AlertErrorMessage = By.CssSelector(".alert-danger");
        By AlertSuccess = By.CssSelector("#center_column");
        By TitleMr = By.CssSelector("#uniform-id_gender1");
        //By TitleMrs = By.CssSelector("#uniform-id_gender2");
        By DateOfBirthDays = By.CssSelector("#days");
        By DateOfBirthMonths = By.CssSelector("#months");
        By DateOfBirthYears = By.CssSelector("#years");
        By CheckboxNewsletter = By.CssSelector("#newsletter");
        // Actions
        public void LoadHomePage()
        {
            _driver.Navigate().GoToUrl("http://www.automationpractice.pl/index.php");
        }
        public string getValText()
        {
            /*TimeSpan sleepDuration = TimeSpan.FromSeconds(4);
            Thread.Sleep(sleepDuration);*/
            //Console.WriteLine("KEDATTTRR"+_driver.FindElement(ValidationEmail).Text);
            return _driver.FindElement(ValidationEmail).Text;
        }
        public string getAccountPersonalInfoText()
        {
            /* TimeSpan sleepDuration = TimeSpan.FromSeconds(4);
             Thread.Sleep(sleepDuration);*/ 
            //For TIME BEING ,Thread sleep method is used because since SeleniumExtras.WaitHelpers not supported for 4.7.2 Project
            //OTHERWISE IMPLICIT and EXPLICIT WAITS ARE APPLIED 
            //Console.WriteLine("KEDATTTRR"+_driver.FindElement(ValidationEmail).Text);
            return _driver.FindElement(ValidationPageAuthentication).Text;
        }
        // Buttons
        public void ClickOnSignIn()
        {
            _driver.FindElement(ButtonSignIn).Click();
            TimeSpan slep1 = TimeSpan.FromSeconds(5);
            Thread.Sleep(slep1);
        }
        public void ClickOnCreateAccount()
        {
            /* TimeSpan sleepDuration = TimeSpan.FromSeconds(6);
             Thread.Sleep(sleepDuration);*/
            Assert.That(_driver.FindElement(ButtonCreateAccount).Displayed, Is.True);
            _driver.FindElement(ButtonCreateAccount).Click();
            TimeSpan sleepDuration = TimeSpan.FromSeconds(4);
            Thread.Sleep(sleepDuration);
        }
        public void ClickOnRegister()
        {
            Assert.That(_driver.FindElement(ButtonRegister).Displayed, Is.True);
            _driver.FindElement(ButtonRegister).Click();
            TimeSpan sleepDuration = TimeSpan.FromSeconds(8); //More time requires
            Thread.Sleep(sleepDuration);
        }
        public void ClickOnMr()
        {
            Assert.That(_driver.FindElement(TitleMr).Displayed, Is.True);
            _driver.FindElement(TitleMr).Click();
        }
        public void ClickOnNewsLetter()
        {
            Assert.That(_driver.FindElement(CheckboxNewsletter).Displayed, Is.True);
            _driver.FindElement(CheckboxNewsletter).Click();
        }
        public void DOBDaysSelectDropdown(string day)
        {
            Assert.That(_driver.FindElement(DateOfBirthDays).Displayed, Is.True);
            SelectElement dropDown = new SelectElement(_driver.FindElement(DateOfBirthDays));
            dropDown.SelectByValue(day);
        }
        public void DOBMonthSelectDropdown(string mon)
        {   

            SelectElement dropDown = new SelectElement(_driver.FindElement(DateOfBirthMonths));
            dropDown.SelectByValue(mon);
        }
        public void DOBYearSelectDropdown(string yr)
        {
            SelectElement dropDown = new SelectElement(_driver.FindElement(DateOfBirthYears));
            dropDown.SelectByValue(yr);
        }
        public void EmailTypeMethod(string inputtext)
        {
            _driver.FindElement(InputEmail).SendKeys(inputtext);
        }
        public void FnameTypeMethod(string fname)
        {
            _driver.FindElement(InputFirstName).SendKeys(fname);
        }
        public void LnameTypeMethod(string lname)
        {
            _driver.FindElement(InputLastName).SendKeys(lname);
        }
        public void PwdTypeMethod(string pwd)
        {
            _driver.FindElement(InputPassword).SendKeys(pwd);
        }
        // Assertions
        public void AssertOneErrorMessage()
        {
            Assert.That(_driver.FindElement(AlertErrorMessage).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertErrorMessage).Text, Does.Contain("There is 1 error"));
        }
        public void AssertTwoErrorMessage()
        {
            Assert.That(_driver.FindElement(AlertErrorMessage).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertErrorMessage).Text, Does.Contain("There are 2 errors"));
        }
        public void AssertThreeErrorMessage()
        {
            Assert.That(_driver.FindElement(AlertErrorMessage).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertErrorMessage).Text, Does.Contain("There are 3 errors"));
        }
        public void AssertFiveErrorMessage()
        {
            Assert.That(_driver.FindElement(AlertErrorMessage).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertErrorMessage).Text, Does.Contain("There are 5 errors"));
        }
        public void AssertInvalidDateOfBirth()
        {
            Assert.That(_driver.FindElement(AlertErrorMessage).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertErrorMessage).Text, Does.Contain("Invalid date of birth."));
        }
        public void AssertMyAccount()
        {
            Assert.That(_driver.FindElement(AlertSuccess).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertSuccess).Text, Does.Contain("My account"));
        }
        public void AssertAccountHasBeenCreated()
        {
            Assert.That(_driver.FindElement(AlertSuccess).Displayed, Is.True);
            Assert.That(_driver.FindElement(AlertSuccess).Text, Does.Contain("Your account has been created."));
        }
        public void AlertCreateAccount()
        {
            Assert.That(_driver.FindElement(ValidationEmail).Displayed, Is.True);
            Assert.That(_driver.FindElement(ValidationEmail).Text, Does.Contain("An account using this email address has already been registered. Please enter a valid password or request a new one."));
        }
    }
}