using LightInject;
using System;

namespace SalaryCalculatorLibrary
{
    public class SalaryCalculator : ISalaryCalculator
    {

        public SalaryCalculator(IServiceContainer sc)
        {
            serviceContainer = sc;
        }

        public virtual decimal GetSuperannuationPercentage()
        {
            const decimal superPercentage = 9.5m;
            return superPercentage;
        }

        public SalaryDetails Calculate(decimal grossPackage, PayFrequency payFrequency)
        {
            var sd = serviceContainer.GetInstance<SalaryDetails>();
            sd.GrossPackage = grossPackage;
            // gross package = taxable income + 9.5 of taxable income
            sd.TaxableIncome = Round(grossPackage * 100 / (100 + GetSuperannuationPercentage()));
            sd.Superannuation = Round(grossPackage - sd.TaxableIncome);

            var deductions = sd.GetDeductions();
            sd.NetIncome = Round(grossPackage - sd.Superannuation - deductions);

            sd.Payfrequency = payFrequency;
            sd.PayPacket = CalculatePayPacket(sd.NetIncome, payFrequency);
            return sd;
        }

        private IServiceContainer serviceContainer;

        //TODO: Add unit tests 
        internal static decimal CalculatePayPacket(decimal annualNetIncome, PayFrequency payFrequency)
        {
            const decimal numberOfWeeksInYear = 52.1786m;
            const decimal numberOfMonthsInYear = 12;

            decimal pay = 0;

            switch (payFrequency)
            {
                case PayFrequency.Weekly:
                    pay = annualNetIncome / numberOfWeeksInYear;
                    break;
                case PayFrequency.Fortnightly:
                    pay = annualNetIncome * 2 / numberOfWeeksInYear;
                    break;
                case PayFrequency.Monthly:
                    pay = annualNetIncome / numberOfMonthsInYear;
                    break;
                default:
                    throw new ArgumentException($"PayFrequency '{payFrequency}' is not an supported.");
            }

            return Round(pay);
        }

        private static decimal Round(decimal value)
        {
            const int decimalPlaces = 2;
            return Math.Round(value, decimalPlaces);
        }
    }
}
