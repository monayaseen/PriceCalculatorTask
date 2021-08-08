using System;

namespace PriceCalculatorTask
{
    public class Discount
    {
        private double discountPersantage = 0.0;

        public double DiscountPersantage
        {
            get { return discountPersantage; }
            set
            {
                bool isValidDiscountPercentage = value >= 0 && value <= 100;
                if (isValidDiscountPercentage)
                    discountPersantage = value / 100.0;
                else throw new Exception("Only from 0 to 100 Percentages are valid");
            }
        }

        public Discount(double discountPersantage)
        {
            DiscountPersantage = discountPersantage;
        }
    }
}