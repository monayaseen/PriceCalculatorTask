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

        public bool IsUpcDiscountBeforTax = false;
        
         public double TaxAmount(Tax tax)
         {
             double taxAmount = Math.Round(Price * (tax.TaxPercentage), 2);
             return taxAmount;
         }
        public double PriceAfterTax(Tax tax)
        {
           return TaxAmount(tax) + Price;
        }
        public double DiscountAmount(Discount discount)
        {
            double discountAmount = Math.Round(Price * (discount.Percentage), 2);
            return  discountAmount;
        }
        public double PriceAfterDiscount(Discount discount)
        {
            return Price - DiscountAmount(discount);
        }
        public double PriceAfterTaxThenDiscount(Tax tax ,Discount discount)
        {
            return PriceAfterTax(tax)- DiscountAmount(discount);
        }
        public double PriceAfterDiscountThenTax(Tax tax, Discount discount)
        {
            return (PriceAfterDiscount(discount) * TaxAmount(tax)) +PriceAfterDiscount(discount);
        }
        public double CalculatePriceWithTaxAndDiscount( Tax tax, Discount discount)
        {
            if (discount._isDiscountBeforeTax)
            {
                return PriceAfterDiscountThenTax(tax,discount);
            } 
            return PriceAfterTaxThenDiscount(tax,discount);
        }
        
        public void ProductPriceReport(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxThenDiscount(tax,discount)}$ is the Price And " +
                              $"{DiscountAmount(discount)}$ was deduced");
        }
        
        public void ProductPriceReportWithNoDiscount(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxThenDiscount(tax,discount)}$ is the Price And No Discount. ");
        }
        
        public double UPCDiscountAmount(Discount discount)
        {
            double upcDiscountAmount = Math.Round( UPCDiscountPercentage * Price, 2);
            return  upcDiscountAmount;
        }
        
        public double PriceAfterUPCDiscount( Tax tax,Discount discount)
        {
            return  Math.Round(PriceAfterTaxThenDiscount(tax, discount)-UPCDiscountAmount(discount),2);
        }
        public double CalculatePriceWithTaxAndUpcDiscount( Tax tax, Discount discount)
        {
            if (IsUpcDiscountBeforTax)
            {
                return PriceAfterUPCDiscount(tax,discount) * UPCDiscountAmount(discount)+PriceAfterUPCDiscount(tax,discount);
            } 
            return PriceAfterUPCDiscount(tax,discount)- UPCDiscountAmount(discount);
        } 
        
    }
}