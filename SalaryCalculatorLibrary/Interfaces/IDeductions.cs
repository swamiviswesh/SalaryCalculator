using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorLibrary
{
    public interface IDeductions
    {
        void Apply(decimal taxableIncome);
    }
}
