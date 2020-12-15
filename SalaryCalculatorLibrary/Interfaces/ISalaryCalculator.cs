namespace SalaryCalculatorLibrary
{
    public interface ISalaryCalculator
    {
        SalaryDetails Calculate(decimal grossPackage, PayFrequency payFrequency);
    }
}