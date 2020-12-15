using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public class DeductionSlab
    {
        public DeductionSlab(decimal rangeStart, decimal rangeEnd, decimal percentage)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
            Percentage = percentage;
        }

        public decimal RangeStart { get; }
        public decimal RangeEnd { get; }
        public decimal Percentage { get; }
    }
}
