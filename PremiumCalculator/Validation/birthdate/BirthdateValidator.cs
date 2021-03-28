using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremiumCalculator.Validation.birthdate
{
    public class BirthdateValidator
    {

        public Boolean ValidateBirthdate(DateTime date, int age)

        {
            DateTime birthdate = date.Date;
            int calculatedAge = DateTime.Today.Year - birthdate.Year - 1;

            //Pass both dates to the same year so i can compare month and days
            //2020 was a leap year, so all dates should be valid
            birthdate = new DateTime(2020, birthdate.Month, birthdate.Day);
            DateTime auxDate = new DateTime(2020, DateTime.Today.Month, DateTime.Today.Day);

            if (birthdate <= auxDate) calculatedAge++;

            if (calculatedAge == age) return true;
            else return false;
        }

    }
}