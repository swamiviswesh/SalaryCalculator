# SalaryCalculator
Calculates the net pay by computing the superannuation and deductions based on Australian Income rules  

Income rules:
1. Taxable income (TI) is gross package minus superannuation contribution and is rounded down to the nearest
dollar when calculating deductions. 
2. Super contribution is 9.5% - note that the value entered by the user is the full package which is inclusive of super.
E.g. package of $50,000 includes super of $4,338. Super should be rounded up to the nearest cent and is based
on an unrounded Taxable income.
3. Medicare Levy (always rounded up to the nearest dollar):
Taxable income range   Medicare Levy                              Example
$0 - $21,335           0%                                         0
$21,336 – $26,668      10% of the excess over $21,335             TI = $25,000, Levy = 25000-21335*10% = $366.50 ($367)
$26,669 and over       2% of taxable income                       TI = $40,000, Levy = 40000*2% = $800
4. Budget Repair Levy (always rounded up to the nearest dollar):
Taxable income range   Budget Repair Levy                         Example
$0 - $180,000          0%                                         0
$180,001 and over      2% of the excess over $180,000             TI = $200,000, Levy = 200000-180000*2% = $400
5. Income Tax: (always rounded up to the nearest dollar)
Taxable income range   Income Tax amount                          Example
$0 - $18,200           0%                                         0
$18,201 – $37,000      19% of the excess over $18,200             TI = $25,000, Tax = 25000-18200*19% =$1,292
$37,001 - $87,000      $3,572 + 32.5% of the excess over $37,000  TI = $45,000, Tax = $3,572 + (45000-37000*32.5%) = $6,172
$87,001 - $180,000     $19,822 + 37% of the excess over $87,000   TI = $95,000, Tax = $19,822 + (95000-87000*37%) = $22,782
$180,001 and over      $54,232 + 47% of the excess over $180,000  TI = $200,000, Tax = $54,232 + (200000-180000*47%) = $63,632
6. Net income is Gross package – super – deductions
7. Pay packet amount is Net salary for the specified pay frequency, i.e. weekly, fortnightly or monthly take home
amount and is rounded up to the nearest cent

This repository includes a Console application "Salary" which uses the "SalaryCalculatorLibrary" to calcluate the salary details 
and prints the corresponding package in the console.