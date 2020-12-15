using System.ComponentModel.DataAnnotations;

namespace SalaryCalculatorLibrary
{
    public enum PayFrequency
    {
        [Display(Name = "per week")]
        Weekly = 0,
        [Display(Name = "per fortnight")]
        Fortnightly = 1,
        [Display(Name = "per month")]
        Monthly = 2
    }
}