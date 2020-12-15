using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public class MedicareLevyDeduction : DeductionsBase
    {
        public MedicareLevyDeduction()
        {
            deductionSlabs = new List<DeductionSlab>()
            {
                new DeductionSlab(0, 21335,0),
                new DeductionSlab(21336, 26668, 10),
                new DeductionSlab(26669, Decimal.MaxValue, 2)
            };
        }
    }
}
