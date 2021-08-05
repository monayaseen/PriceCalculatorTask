using System;
using Xunit;
using PriceCalculatorTask;

namespace PriceCalculatorTask.Test
{
    public class CheckTaxValidity
    {
        [Fact]
        public void Multiply_Tax_Price_Returns_PriceAfterTax()
        {
            var product = new Product()
            {
                Name = "The Little Prince",
                UPC = 12345,
                Price = 20.253,
            };
            var tax = new Tax(20);
            var actual = product.PriceAfterTax(tax);
            Assert.Equal(24.3,actual);


        }
    }
}