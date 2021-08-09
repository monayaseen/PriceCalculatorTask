using System;

namespace PriceCalculatorTask
{
    public class Tax
    {
        private double _percentage = 0.2;
        public double TaxPercentage
        {
            get
            {
                return _percentage;
            }
            set
            {
                _percentage= value.CheckPercentageValidation();
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