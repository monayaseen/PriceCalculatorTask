using System;

namespace PriceCalculatorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Tax tax = new Tax();
            Product product = new Product()
            {
                Name = "The Little Prince",
                UPC = 12345,
                Price = 20.253,
            };
            
            tax.taxPercentage = 21;
            product.PriceBeforeAndAfterTax();
        }
    }
}