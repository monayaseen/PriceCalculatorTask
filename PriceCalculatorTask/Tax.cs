using System;

namespace PriceCalculatorTask
{
    public class Tax
    {
        public double taxPercentage = 0.2;
        public double TaxPercentage
        {
            get
            {
                return taxPercentage;
            }
            set
            {
                bool isValidTaxPercentage = value >= 0 && value <= 100;
                if (isValidTaxPercentage) 
                    taxPercentage = value / 100.0;
                else throw new Exception("Only from 0 to 100 Percentages are valid");
            }
        }
        public Tax(double taxPercentage)
        {
            TaxPercentage = taxPercentage;
        }
        public Tax()
        {
            TaxPercentage = 20;
        }
    }
}