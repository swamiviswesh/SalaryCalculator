using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public class IncomeTaxDeduction : DeductionsBase
    {
        public IncomeTaxDeduction()
        {
            deductionSlabs = new List<DeductionSlab>()
            {
                new DeductionSlab(0, 18200, 0),
                new DeductionSlab(18201, 37000, 19),
                new DeductionSlab(37001, 87000, 32.5m),
                new DeductionSlab(87001, 180000, 37),
                new DeductionSlab(180001, Decimal.MaxValue, 47)
            };
        }
    }
}
