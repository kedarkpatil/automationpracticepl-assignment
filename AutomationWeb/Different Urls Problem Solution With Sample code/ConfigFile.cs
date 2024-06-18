using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWeb.Different_Urls_Problem_Solution_With_Sample_code
{
    class ConfigFile
    {
        public static string GetBaseUrlFromConfig(string countryCode)
        {
            // e.g., "https://www.automationpractice.com/us" or "https://www.automationpractice.co.in" or "https://www.automationpractice.co.de"
            return $"https://www.automationpractice.{countryCode.ToLower()}";
        }

        public static string GetUsernameFromConfig(string countryCode)
        {
            // Return the username for the specified country code
            // e.g., "us_user" or "uk_user"
            return $"{countryCode.ToLower()}_user";
        }

        public static string GetPasswordFromConfig(string countryCode)
        {
            // Return the password for the specified country code
            // e.g., "us_password" or "uk_password"
            return $"{countryCode.ToLower()}_password";
        }
    }
}
