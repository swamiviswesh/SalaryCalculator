using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public class SalaryDetails
    {
        public SalaryDetails(MedicareLevyDeduction medicareLevyDeduction, 
            BudgetRepairLevyDeduction budgetRepairLevyDeduction,
            IncomeTaxDeduction incomeTaxDeduction)
        {
            MedicareLevyDeduction = medicareLevyDeduction;
            BudgetRepairLevyDeduction = budgetRepairLevyDeduction;
            IncomeTaxDeduction = incomeTaxDeduction;
        }

        public decimal GetDeductions()
        {
            BudgetRepairLevyDeduction.Apply(TaxableIncome);
            MedicareLevyDeduction.Apply(TaxableIncome);
            IncomeTaxDeduction.Apply(TaxableIncome);

            return BudgetRepairLevyDeduction.Deduction + MedicareLevyDeduction.Deduction + IncomeTaxDeduction.Deduction;
        }

        public string PrettyPrint()
        {
            var output = new StringBuilder();
            output.AppendLine();
            output.AppendLine($"Gross package: {Currency(GrossPackage)}");
            output.AppendLine($"Superannuation: {Currency(Superannuation)}");
            output.AppendLine();
            output.AppendLine($"Taxable income: {Currency(TaxableIncome)}");
            output.AppendLine();
            output.AppendLine("Dedictions:");
            output.AppendLine($"Medicare Levy: {Currency(MedicareLevyDeduction.Deduction)}");
            output.AppendLine($"Budget Repair Levy: {Currency(BudgetRepairLevyDeduction.Deduction)}");
            output.AppendLine($"Income Tax: {Currency(IncomeTaxDeduction.Deduction)}");
            output.AppendLine();
            output.AppendLine($"Net income: {Currency(NetIncome)}");
            output.AppendLine($"Pay packet: {Currency(PayPacket)} {GetDisplayName(Payfrequency)}");
            return output.ToString();
        }

        public decimal GrossPackage { get; set; }
        public decimal Superannuation { get; set; }
        public decimal TaxableIncome { get; set; }

        public decimal NetIncome { get; set; }

        public decimal PayPacket { get; set; }

        public PayFrequency Payfrequency { get; set; }

        private MedicareLevyDeduction MedicareLevyDeduction { get; set; }
        private BudgetRepairLevyDeduction BudgetRepairLevyDeduction { get; set; }
        private IncomeTaxDeduction IncomeTaxDeduction { get; set; }

        //Get the name from the enum display attribute.
        private static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }

        //Get the value in currecny format.
        private static string Currency(decimal value)
        {
            //TODO: Pass the precision required
            return value.ToString("C");
        }


    }
}