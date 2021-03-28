using System;

namespace PremiumCalculator.Calculation
{
    public class Calculator
    {


        public Double GetPremium(DateTime birthDate, String state, int age)
        {

            int month = birthDate.Month;

            if (state.ToUpper().Equals("NY"))
            {

                if (month == 8 && (age >= 18 && age <= 45)) return 150.00;

                if (month == 1 && (age >= 46 && age <= 65)) return 200.50;

                if (age >= 18 && age <= 65) return 120.99;
            }
            else if (state.ToUpper().Equals("AL"))
            {

                if (month == 11 && (age >= 18 && age <= 65)) return 85.5;

                if (age >= 18 && age <= 65) return 100.00;

            }
            else if (state.ToUpper().Equals("AK"))
            {
                if (month == 12)
                {
                    if (age >= 65) return 175.20;
                    if (age >= 18 && age <= 64) return 125.16;

                }

                if (age >= 18 && age <= 65) return 100.80;

            }
            else if (age >= 18 && age <= 65) return 90.00;

            return 0;
        }

    }
}