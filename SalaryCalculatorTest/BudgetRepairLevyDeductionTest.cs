using SalaryCalculatorLibrary;
using FluentAssertions;
using Xunit;

namespace SalaryCalculatorLibraryTest
{
    public class BudgetRepairLevyDeductionTest
    {

        [Theory]
        [InlineData(59360.73, 0)]
        public void Apply_WhenTaxableIncomeIsValid_ReturnsCorrectDeduction(decimal taxableIncome, decimal expectedBudgetRepairLevy)
        {
            //Arrange
            var sut = new BudgetRepairLevyDeduction();
            //Act
            sut.Apply(taxableIncome);
            //Assert
            sut.Deduction.Should().Be(expectedBudgetRepairLevy);
        }

    }
}
