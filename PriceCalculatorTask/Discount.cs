using System;

namespace PriceCalculatorTask
{
    public class Discount
    {
        public bool _isDiscountBeforeTax = false;

        private double _percentage  = 0.0;
        public double Percentage 
        {
            get { return _percentage ; }
            set
            {
                _percentage=value.CheckPercentageValidation();
            }
        }
              //
              // public double _discountType;
              // private double _discountBeforeTax=0;
              // private double _discountAfterTax=1;

              public Discount(double discountPercentage,bool isDiscountBeforeTax)
              {
                  _isDiscountBeforeTax= isDiscountBeforeTax ;
            Percentage = discountPercentage;
        }
    }
}