using SalaryCalculatorLibrary;
using FluentAssertions;
using Xunit;

namespace SalaryCalculatorLibraryTest
{
    public class IncomeTaxDeductionTest
    {

        [Theory]
        [InlineData(59360.73, 10839.00)]
        public void Apply_WhenTaxableIncomeIsValid_ReturnsCorrectDeduction(decimal taxableIncome, decimal expectedValue)
        {
            //Arrange
            var sut = new IncomeTaxDeduction();
            //Act
            sut.Apply(taxableIncome);
            //Assert
            sut.Deduction.Should().Be(expectedValue);
        }


    }
}
