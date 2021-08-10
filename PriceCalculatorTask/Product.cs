using System;
using System.Threading.Tasks;

namespace PriceCalculatorTask
{
    public class Product
    {
        private string _name { get; set; }
        public int _upc { get; set; }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = Math.Round(value, 2); }
        }
        public double _upcDiscountPercentage;
        public double UPCDiscountPercentage
        {
            get { return _upcDiscountPercentage; }
            set { _upcDiscountPercentage = value.CheckPercentageValidation(); }
        }
        public bool IsUpcDiscountBeforTax = false;
        
    }
}