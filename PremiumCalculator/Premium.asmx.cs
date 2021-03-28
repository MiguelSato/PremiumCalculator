using Newtonsoft.Json.Linq;
using PremiumCalculator.Calculation;
using PremiumCalculator.Validation;
using PremiumCalculator.Validation.birthdate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace PremiumCalculator
{
    /// <summary>
    /// Summary description for Premium
    /// </summary>
    [WebService(Namespace = "http://sato.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Premium : System.Web.Services.WebService
    {


        [WebMethod]
        public string TestConnection()
        {
            String message = "OK!";

            return message;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CalculatePremium(String birthdate, String state, String age)
        {
            try
            {
                //This should throw a exception if the date is invalid
                DateTime date = DateTime.Parse(birthdate);

                //Check if age is numeric
                Boolean isNumeric = int.TryParse(age, out int ageValue);
                if (!isNumeric) throw new Exception("Age is not a valid number.");


                //Check if birthdate and age match

                BirthdateValidator birthdatevalidator = new BirthdateValidator();
                Boolean isValid = birthdatevalidator.ValidateBirthdate(date, ageValue);
                if (!isValid) throw new Exception("Birthdate and age does not match.");


                //check if the state is valid
                StateValidator stateValidator = new StateValidator(); ;
                isValid = stateValidator.IsValid(state);

                if (!isValid) throw new Exception("Invalid state.");

                //

                Calculator calculator = new Calculator();
                double premium = calculator.GetPremium(date, state, ageValue);

                JObject response = new JObject();
                response.Add("error_code", "0");
                response.Add("premium", premium.ToString());

                return response.ToString();
            }
            catch(Exception e)
            {
                JObject response = new JObject();
                response.Add("error_code", "M1");
                response.Add("error_message", e.Message);

                return response.ToString();
            }

        }


    }
}
