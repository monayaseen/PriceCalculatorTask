using System;

namespace PriceCalculatorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Tax tax = new Tax(20);
            Discount discount = new Discount(0);
            Product product = new Product()
                {
                    Price = 20.25
                }
            ;
            if (discount.DiscountPersantage==0.0)
            {
                product.ProductPriceReportWithNoDiscount(tax, discount);
            }
            else
                product.ProductPriceReport(tax, discount);

        }
    }
}