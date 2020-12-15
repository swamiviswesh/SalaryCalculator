using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public class BudgetRepairLevyDeduction : DeductionsBase
    {
        public BudgetRepairLevyDeduction()
        {
            deductionSlabs = new List<DeductionSlab>()
            {
                new DeductionSlab(0, 180000, 0),
                new DeductionSlab(180001, Decimal.MaxValue, 2)
            };
        }
    }
}
