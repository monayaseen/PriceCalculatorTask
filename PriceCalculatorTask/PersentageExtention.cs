using System;

namespace PriceCalculatorTask
{
    public static class PercentageExtension
    {
        public static double CheckPercentageValidation(this  double percentage)
        {
            bool isValidDiscountPercentage = percentage >= 0 && percentage <= 100;
            if (isValidDiscountPercentage)
                percentage = percentage / 100.0;
            else throw new Exception("Only from 0 to 100 Percentages are valid");
            return percentage;
        }
    }
    
    
    
    
    
}