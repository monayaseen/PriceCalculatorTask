using System;

namespace PriceCalculatorTask
{
    public class Calculations
    {
        private Product _product = new Product()
        {
            Price = 20.253,
            UPCDiscountPercentage=7,
            _upc=1234,
            IsUpcDiscountBeforTax=true
        };
         private Tax _tax = new Tax();
         private Discount _discount = new Discount();
        public Calculations(Product product)
        {
            product.Price = 20.253;
        }
        public double PriceAfterTaxThenDiscount(Tax tax ,Discount discount)
        {
            return tax.PriceAfterTax(tax)- discount.DiscountAmount(discount);
        }
        public double PriceAfterDiscountThenTax(Tax tax, Discount discount)
        {
            return Math.Round(discount.PriceAfterDiscount(discount)*tax.TaxPercentage  +discount.PriceAfterDiscount(discount),2);
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
                              $"{discount.DiscountAmount(discount)}$ was deduced");
        }
        
        public void ProductPriceReportWithNoDiscount(Tax tax ,Discount discount)
        {
            Console.WriteLine($"{PriceAfterTaxThenDiscount(tax,discount)}$ is the Price And No Discount. ");
        }
        
        public double UPCDiscountAmount()
        {
            double upcDiscountAmount = Math.Round( _product.UPCDiscountPercentage * _product.Price, 2);
            return  upcDiscountAmount;
        }
        
        public double PriceAfterUPCDiscount( Tax tax,Discount discount)
        {
            return  Math.Round(PriceAfterTaxThenDiscount(tax, discount)-UPCDiscountAmount(),2);
        }
        public double CalculatePriceWithTaxAndUpcDiscount( Tax tax, Discount discount)
        {
            if (_product.IsUpcDiscountBeforTax)
            {
                return Math.Round(PriceAfterUPCDiscount(tax,discount) * _product._upcDiscountPercentage+PriceAfterUPCDiscount(tax,discount),2);
            } 
            return PriceAfterUPCDiscount(tax,discount)- UPCDiscountAmount();
        }

        public double TotalDiscountsAmount(Discount discount)
        {
            return ( discount.DiscountAmount(discount)) + (UPCDiscountAmount());
        }

        public double PriceAfterTotalDiscount(Tax tax, Discount discount)
        {
            return  Math.Round(tax.PriceAfterTax(tax)-TotalDiscountsAmount(discount),2);
        }
        public double TotalCostCalculation(AnotherCosts costs)
        {
            double packagingAmount = _product.Price * (costs.PackagingCost);
            return Math.Round( packagingAmount+costs.TransportCost,2) ;
        }
        public double TotalCost(Tax tax, Discount discount, AnotherCosts costs)
        {
            return Math.Round(PriceAfterTotalDiscount(tax, discount) + TotalCostCalculation(costs),2);
        }
        
    }
}