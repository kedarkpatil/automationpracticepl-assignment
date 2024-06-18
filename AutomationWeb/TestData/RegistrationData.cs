using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWeb.TestData
{
        public static class RegistrationData
        {   
            //STATIC CLASS FOR TEST DATA
            public const string FirstName = "Kedar";
            public const string LastName = "Patil";
            public const string UserEmail = "kkpatil999@gmail.com";
            public const string UserPassword = "564tc";
            public const string BirthDay = "26";
            public const string BirthMonth = "June";
            public const string BirthYear = "1994";

            // Registration Emails for Input
            public const string UserEmailWithSpace = " kkpatil999@gmail.com";
            public const string UserEmailWithSemicolon = ";kkpatil999@gmail.com";
            public const string UserEmailWithDotAtEnd = "kkpatil999@gmail.com.";

            // Registration form Fields Input Valid data
            public const string UserFirstNameValid = "Kedar";
            public const string UserLastNameValid = "Patil";
            public const string UserEmailValid = "verification@yahoo.com";
            public const string UserPasswordValid = "23abc91";
          /*  public const string UserPasswordShort = "1a2b";
            public const string UserPasswordNumbers = "12345";
            public const string OneSpace = " ";
            public const string FiveSpace = "     ";*/

            // Validation Error message
            public const string OneErrorMessage = "There is 1 error";
            public const string TwoErrorMessage = "There are 2 errors";
            public const string ThreeErrorMessage = "There are 3 errors";
        }

}
