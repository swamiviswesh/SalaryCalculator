using SalaryCalculatorLibrary;
using FluentAssertions;
using Xunit;

namespace SalaryCalculatorLibraryTest
{
    public class MedicareLevyDeductionTest
    {

        [Theory]
        [InlineData(59360.73, 1188)]
        [InlineData(40000, 800)]
        public void Calculate_WhenTaxableIncomeIsValid_ReturnsCorrectDeduction(decimal taxableIncome, decimal expectedMedicareLevy)
        {
            //Arrange
            var sut = new MedicareLevyDeduction();
            //Act
            sut.Apply(taxableIncome);
            //Assert
            sut.Deduction.Should().Be(expectedMedicareLevy);

        }
    }
}
