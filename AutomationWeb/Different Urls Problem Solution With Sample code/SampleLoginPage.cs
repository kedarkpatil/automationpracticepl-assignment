using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWeb.Different_Urls_Problem_Solution_With_Sample_code
{
    class SampleLoginPage
    {
        private readonly IWebDriver _driver;

        public SampleLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterUsername(string username)
        {
            _driver.FindElement(By.Id(GetElementId("username", _driver))).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(By.Id(GetElementId("password", _driver))).SendKeys(password);
        }

        public void ClickLogin()
        {
            _driver.FindElement(By.Id(GetElementId("loginButton", _driver))).Click();
        }

        public bool IsLoggedIn
        {
            get { return _driver.Title.Contains("Dashboard"); }
        }

    }
}
