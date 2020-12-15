using Xunit;
using SalaryCalculatorLibrary;
using FluentAssertions;
using LightInject;

namespace SalaryCalculatorLibraryTest
{
    public class SalaryCalculatorTest
    {
        [Theory]
        [InlineData(65000, 5639.27, 59360.73, 47333.73, 3944.48)]
        public void Calculate_WhenGrossPackageIsValid_ReturnsCorrectSalary(decimal grossPackage, 
            decimal expectedSuperannuation, decimal expectedTaxableIncome, decimal expectedNetIncome, 
            decimal expectedPayPacket)
        {
            //Arrange
            var sc = new ServiceContainer();
            sc.Register<SalaryDetails>((c) =>
            {
                var medicareLevyDeduction = c.GetInstance<MedicareLevyDeduction>();
                var budgetRepairLevyDeduction = c.GetInstance<BudgetRepairLevyDeduction>();
                var incomeTaxDeduction = c.GetInstance<IncomeTaxDeduction>();

                return new SalaryDetails(medicareLevyDeduction, budgetRepairLevyDeduction, incomeTaxDeduction);
            }, new PerContainerLifetime());
            sc.Register<MedicareLevyDeduction>();
            sc.Register<BudgetRepairLevyDeduction>();
            sc.Register<IncomeTaxDeduction>();

            var sut = new SalaryCalculator(sc);
            //Act
            var salaryDetails = sut.Calculate(grossPackage, PayFrequency.Monthly);

            //Assert
            salaryDetails.Superannuation.Should().Be(expectedSuperannuation);
            salaryDetails.TaxableIncome.Should().Be(expectedTaxableIncome);
            salaryDetails.NetIncome.Should().Be(expectedNetIncome);
            salaryDetails.PayPacket.Should().Be(expectedPayPacket);
        }
        
    }
}
