using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationWeb.Different_Urls_Problem_Solution_With_Sample_code;

namespace AutomationWeb.Different_Urls_Problem_Solution_With_Sample_code
{
    class ValidationTests
    {
        //Using Data Driven and Parameterised Test approach using config file
        [TestFixture("us")] //usa website url domain
        [TestFixture("in")] // india website url domain 
        [TestFixture("de")] // germany website url domain
        public class AuthenticationTests
        {
            private readonly string _countryCode;
            private readonly string _baseUrl;
            private readonly string _username;
            private readonly string _password;

            //url,uname and pwd is created from config file from Passing parameters to config file
            public AuthenticationTests(string countryCode)
            {
                _countryCode = countryCode;
                _baseUrl = ConfigFile.GetBaseUrlFromConfig(countryCode);
                _username = ConfigFile.GetUsernameFromConfig(countryCode);
                _password = ConfigFile.GetPasswordFromConfig(countryCode);
            }

            [Test]
            public void Login_WithValidCredentials_ReturnsOk()
            {
                // Arrange
                var driver = new ChromeDriver();
                driver.Navigate().GoToUrl(_baseUrl);

                // Act
                var loginPage = new LoginPage(driver);
                loginPage.EnterUsername(_username);
                loginPage.EnterPassword(_password);
                loginPage.ClickLogin();

                // Assert
                Assert.IsTrue(loginPage.IsLoggedIn);
            }

        }


    }
}
