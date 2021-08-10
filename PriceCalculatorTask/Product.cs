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
            return Math.Round(PriceAfterDiscount(discount)*tax.TaxPercentage  +PriceAfterDiscount(discount),2);
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
        
        public double UPCDiscountAmount()
        {
            double upcDiscountAmount = Math.Round( UPCDiscountPercentage * Price, 2);
            return  upcDiscountAmount;
        }
        
        public double PriceAfterUPCDiscount( Tax tax,Discount discount)
        {
            return  Math.Round(PriceAfterTaxThenDiscount(tax, discount)-UPCDiscountAmount(),2);
        }
        public double CalculatePriceWithTaxAndUpcDiscount( Tax tax, Discount discount)
        {
            if (IsUpcDiscountBeforTax)
            {
                return Math.Round(PriceAfterUPCDiscount(tax,discount) * _upcDiscountPercentage+PriceAfterUPCDiscount(tax,discount),2);
            } 
            return PriceAfterUPCDiscount(tax,discount)- UPCDiscountAmount();
        }

        public double TotalDiscountsAmount(Discount discount)
        {
            return ( DiscountAmount(discount)) + (UPCDiscountAmount());
        }

        public double PriceAfterTotalDiscount(Tax tax, Discount discount)
        {
            return  Math.Round(PriceAfterTax(tax)-TotalDiscountsAmount(discount),2);
        }
        public double TotalCostCalculation(AnotherCosts costs)
        {
            double packagingAmount = Price * (costs.PackagingCost);
            return Math.Round( packagingAmount+costs.TransportCost,2) ;
        }
        public double TotalCost(Tax tax, Discount discount, AnotherCosts costs)
        {
            return Math.Round(PriceAfterTotalDiscount(tax, discount) + TotalCostCalculation(costs),2);
        }
    }
}