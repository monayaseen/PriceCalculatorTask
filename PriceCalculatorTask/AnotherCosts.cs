using System;

namespace PriceCalculatorTask
{
    public class AnotherCosts
    {
        private double _packagingCost=0.0;

        public double PackagingCost
        {
            get { return _packagingCost; }
            set
            {
                _packagingCost = value.CheckPercentageValidation();
                
            }
        }
        public double TransportCost;
    }
}