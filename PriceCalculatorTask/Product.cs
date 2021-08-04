using System;
using System.Threading.Tasks;

namespace PriceCalculatorTask
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double price;
        public double Price
        {
            get { return price; }
            set { price = Math.Round(value, 2); }
        }
        public double PriceAfterTax(Tax tax)
        {
            double PriceWithTax = Math.Round(Price * ( tax.TaxPercentage) + Price,2);
            return PriceWithTax;
        }
        
    }
}