using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public abstract class DeductionsBase : IDeductions
    {
        internal List<DeductionSlab> deductionSlabs;
        public decimal  Deduction { get; private set; }

        public void Apply(decimal taxableIncome)
        {
            var fullDeduction = deductionSlabs.Where(x => x.RangeEnd < taxableIncome)
                                .Sum(x => (x.RangeEnd - x.RangeStart) * x.Percentage/100);

            var partialDeduction = deductionSlabs.Where(x => x.RangeStart <= taxableIncome && x.RangeEnd >= taxableIncome)
                                   .Sum(x => (taxableIncome - x.RangeStart) * x.Percentage/100);

            Deduction =  Math.Ceiling(fullDeduction + partialDeduction);
        }
    }
}
