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
        private double _upcDiscountPercentage;
        public double UPCDiscountPercentage
        {
            get { return _upcDiscountPercentage; }
            set { _upcDiscountPercentage = value.CheckPercentageValidation(); }
        }
        
        public double PriceAfterTax(Tax tax)
        {
            double PriceWithTax = Math.Round(Price * ( tax.TaxPercentage) + Price,2);
            return PriceWithTax;
        }

        public double PriceAfterTaxAndDiscount(Tax tax ,Discount discount)
        {
            double PriceWithTaxAndDiscount = Math.Round((Price * discount.Percentage), 2);
            return PriceAfterTax(tax)- PriceWithTaxAndDiscount;
        }

        public void ProductPriceReport(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxAndDiscount(tax,discount)}$ is the Price And " +
                              $"{ Math.Round(price * discount.Percentage,2)}$ was deduced");
        }
       
        public void ProductPriceReportWithNoDiscount(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxAndDiscount(tax,discount)}$ is the Price And No Discount. ");
        }

        public double PriceAfterUPCDiscount( Tax tax,Discount discount)
        {
            double PriceWithUPDDiscount =Math.Round( UPCDiscountPercentage * Price, 2);
            return  Math.Round(PriceAfterTaxAndDiscount(tax, discount)-PriceWithUPDDiscount,2);


        }
    }
}