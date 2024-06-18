using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using NUnit.Framework;
//using DotNetSeleniumExtras.WaitHelpers;
using RestSharp;
using RestSharp.Authenticators;
namespace AutomationWeb.ApiTests
{
    [TestFixture]
    //API TESTS FOR GET and POST
    class ApiAutomationTest
    {
        private readonly string _baseUrl = "http://www.automationpractice.pl";
        private readonly string _categoryId = "3";
        private readonly string _categorycontroller = "category";
        private readonly string _identitycontroller = "identity";
        private readonly string _authenticatiocontroller = "authentication";
        [Test] //Test for Getting Category 
        public void GetCategory_WithValidId_Returns200OkGetSucesss()
        {
            // Arrange
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($ "index.php?id_category={_categoryId}&controller={_categorycontroller}", Method.Get);
            // Act
            var response = client.Execute(request);
            //Console.Write(response.IsSuccessStatusCode);
            // assert
            // Assert.That(response.IsSuccessStatusCode, Is.EqualTo(200));
            Assert.That(response.IsSuccessStatusCode, Is.True);
            // Assert
        }
        [Test] //Test for Getting Identity
        public void GetCategory_WithValidUserIdentity_Returns200OkGetSucesss()
        {
            // Arrange
            var client = new RestClient(_baseUrl);
            // var request = new RestRequest($"index.php?id_category={_categoryId}&controller={_controller}", Method.Get);
            // Act
            var request = new RestRequest($ "index.php?controller={_identitycontroller}", Method.Get);
            var response = client.Execute(request);
            //Console.Write(response.IsSuccessStatusCode);
            // assert
            // Assert.That(response.IsSuccessStatusCode, Is.EqualTo(200));
            Assert.That(response.IsSuccessStatusCode, Is.True);
            // Assert
        }
        [Test] //Test for Saving User Credentials 
        public void GetCategory_UserIdentityDataCreation_POSTSuccess()
        {
            // **********
            //POST CALL
            var client = new RestClient(_baseUrl);
            // { _controller} = authentication
            var request = new RestRequest($ "index.php?controller={_authenticatiocontroller}", Method.Post);
            // Set the request body with valid data for api
            var requestBody = new
            {
                customer_firstname = "samplefname",
                customer_lastname = "samplelname",
                email = "samplefname@gmail.com",
                passwd = "12345"
            };
            request.AddJsonBody(requestBody);
            // Act
            var response = client.Execute(request);
            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}