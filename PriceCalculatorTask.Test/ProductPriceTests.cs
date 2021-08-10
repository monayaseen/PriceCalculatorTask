using System;
using Xunit;
using PriceCalculatorTask;

namespace PriceCalculatorTask.Test
{
    
    public class CheckTaxValidity
    {
        
        [Theory]
        [InlineData(20.256, 20.26)]
        [InlineData(21.234, 21.23)]
        public void Price_TwoDecimalDigits(double price, double expectedPrice)
        {
            var product = new Product()
            {
                Price = price
            };
            var actual = product.Price;
            Assert.Equal(expectedPrice,actual);
        }
        
       [Theory]
       [InlineData(20,24.3)]
       [InlineData(21,24.5)]
        public void PriceAfterTax_Returns_PriceAfterTaxValue(double taxPercentage,double expected)
        {
            var product = new Product()
            {
                Price = 20.253,
            };
            var tax = new Tax(taxPercentage);
            var actual = tax.PriceAfterTax(tax);
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(15,21.26)]
        public void PriceAfterTaxAndDiscount_Returns_PriceValue(double discountPercentage,double expected)
        { var product = new Product()
                     {
                         Price = 20.253,
                     };
            var calculation = new Calculations(product);
            
            var tax = new Tax(20);
            var discount = new Discount(discountPercentage,false);
            var actual = calculation.PriceAfterTaxThenDiscount(tax, discount);
            Assert.Equal(expected,actual);

        }
        [Theory]
        [InlineData(20,12345,19.84)]
        [InlineData(21,789,20.04)]
        public void PriceAfterUPCDiscount_Returns_PriceValue(double taxPercentage,int upc,double expected)
        { var product = new Product()
                     {
                         Price = 20.253,
                         UPCDiscountPercentage=7,
                         _upc=upc
                     };
            var calculation = new Calculations(product);

            
            var tax = new Tax(taxPercentage);
            var discount = new Discount(15,false);
            var actual = calculation.PriceAfterUPCDiscount(tax,discount);
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(21.23)]
        public void CalculatePriceWithTaxAndUpcDiscount_Returns_PriceValue(double expected)
        {
            var product = new Product()
            {
                Price = 20.253,
                UPCDiscountPercentage=7,
                _upc=1234,
                IsUpcDiscountBeforTax=true
            };
            var calculation = new Calculations(product);
            var tax = new Tax(20);
            var discount = new Discount(15,false);
            var actual = calculation.CalculatePriceWithTaxAndUpcDiscount(tax,discount);
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(20.65)]
        public void CalculatePriceWithTaxAndDiscount_Returns_PriceValue(double expected)
        {
            var product = new Product()
            {
                Price = 20.253,
                UPCDiscountPercentage=7,
                _upc=1234,
                IsUpcDiscountBeforTax=true
            };
            var calculation = new Calculations(product);
            var tax = new Tax(20);
            var discount = new Discount(15,true);
            var actual = calculation.CalculatePriceWithTaxAndDiscount(tax,discount);
            Assert.Equal(expected,actual);
        }
        
        
        [Theory]
        [InlineData(22.44)]
        public void TotalCost_Returns_TotalPriceValue(double expected)
        {
            var product = new Product()
            {
                Price = 20.253,
                UPCDiscountPercentage=7,
                _upc=1234,
                IsUpcDiscountBeforTax=true
            };
            var tax = new Tax(21);
            var discount = new Discount(15,false);
            var costs = new AnotherCosts()
            {
                PackagingCost=1,
                TransportCost=2.2
            };
            var calculation = new Calculations(product);

                var actual = calculation.TotalCost(tax,discount,costs);
            Assert.Equal(expected,actual);
        }
    }
    
}
    
    