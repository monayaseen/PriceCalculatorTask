using System;

namespace PriceCalculatorTask
{
    public class Tax
    {
        private Product _product = new Product()
        {
            Price = 20.253,
            UPCDiscountPercentage=7
        };
        
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
        
        public double TaxAmount(Tax tax)
        {
            double taxAmount = Math.Round(_product.Price * (tax.TaxPercentage), 2);
            return taxAmount;
        }
        public double PriceAfterTax(Tax tax)
        {
            return TaxAmount(tax) + _product.Price;
        }
    }
}