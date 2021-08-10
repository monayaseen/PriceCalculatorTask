using System;

namespace PriceCalculatorTask
{
    public class Discount
    {
        private Product _product = new Product()
        {
            Price = 20.253,
            UPCDiscountPercentage=7
        };
        
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
        public Discount(double discountPercentage,bool isDiscountBeforeTax)
              {
                  _isDiscountBeforeTax= isDiscountBeforeTax ;
            Percentage = discountPercentage;
        }

        public Discount()
        {
            // _isDiscountBeforeTax = false;
            // Percentage = 0;
        }
        public double DiscountAmount(Discount discount)
        {
            double discountAmount = Math.Round(_product.Price * (discount.Percentage), 2);
            return  discountAmount;
        }
        public double PriceAfterDiscount(Discount discount)
        {
            return _product.Price - DiscountAmount(discount);
        }
    }
}