using System;

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
        
        Tax tax = new Tax();
        public void PriceBeforeAndAfterTax()
        {
            double PriceWithTax = Price * ( tax.taxPercentage) + Price;
            Console.WriteLine($"${Price}$ before tax and ${PriceWithTax}$ after {tax.taxPercentage * 100}% tax");
        }
        
    }
}