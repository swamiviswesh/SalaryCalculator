using SalaryCalculatorLibrary;
using LightInject;
using System;

namespace Salary
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Get the user input
            var salaryPackage = GetSalaryPackageInput();
            if (!salaryPackage.HasValue)
            {
                return;
            }
            var payFrequency = GetPayFrequencyUserInput();
            if (!payFrequency.HasValue)
            {
                return;
            }
            var c = GetContainer();

            //Calculate the salary
            Console.WriteLine("\nCalculating salary details...");
            var sc = c.GetInstance<SalaryCalculator>();
            var salary = sc.Calculate(salaryPackage.Value, payFrequency.Value);

            //Print salary details to console
            Console.WriteLine(salary.PrettyPrint());
            Console.WriteLine("\nPress any key to end...");
            Console.ReadKey();

        }

        // Register classes with the LightInject Container
        private static ServiceContainer GetContainer()
        {
            var sc = new ServiceContainer();
            sc.Register<SalaryCalculator>((c) =>
            {
                return new SalaryCalculator(sc);
            }, new PerContainerLifetime());

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
            return sc;
        }
        private static decimal? GetSalaryPackageInput()
        {
            var isValid = false;
            decimal? salaryPackage = null;
            var exit = false;
            do
            {
                Console.Write("Enter your salary package amount: ");
                var salaryPackageString = Console.ReadLine();
                isValid = Decimal.TryParse(salaryPackageString, out decimal salary);
                if (!isValid)
                {
                    Console.WriteLine("\nPress Esc key to exit.");
                    exit = Console.ReadKey(true).Key == ConsoleKey.Escape;
                }
                else
                {
                    salaryPackage = salary;
                }
            } while (!isValid && !exit);
            return salaryPackage;
        }

        private static PayFrequency? GetPayFrequencyUserInput()
        {
            PayFrequency? payFrequency = null;
            var isValid = true;
            var exit = false;

            do
            {
                Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
                var payFrequencyString = Console.ReadKey().KeyChar;

                switch (char.ToLower(payFrequencyString))
                {
                    case 'w':
                        payFrequency = PayFrequency.Weekly;
                        break;
                    case 'f':
                        payFrequency = PayFrequency.Fortnightly;
                        break;
                    case 'm':
                        payFrequency = PayFrequency.Monthly;
                        break;
                    default:
                        isValid = false;
                        break;
                }
                if (!isValid)
                {
                    Console.WriteLine("\nPress Esc key to exit.");
                    exit = Console.ReadKey(true).Key == ConsoleKey.Escape;
                }

            } while (!isValid && !exit);

            return payFrequency;

        }
    }
}
