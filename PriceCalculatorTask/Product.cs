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

        public double PriceAfterTaxAndDiscount(Tax tax ,Discount discount)
        {
            double PriceWithTaxAndDiscount = Math.Round((Price * discount.DiscountPersantage), 2);
            return PriceAfterTax(tax)- PriceWithTaxAndDiscount;
        }

        public void ProductPriceReport(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxAndDiscount(tax,discount)}$ is the Price And " +
                              $"{ Math.Round(price * discount.DiscountPersantage,2)}$ was deduced");
        }
       
        public void ProductPriceReportWithNoDiscount(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxAndDiscount(tax,discount)}$ is the Price And No Discount. ");
        }
    }
}