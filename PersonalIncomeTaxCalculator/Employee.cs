using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalIncomeTaxCalculator
{
    public class Employee
    {
        private readonly ITaxGenerator _taxGenerator;
        public Employee(ITaxGenerator taxGenerator)
        {
            _taxGenerator = taxGenerator;
        }
        public string Name { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxableIncome { get; set; }
        public double PersonalIncomeTax { get; set; }

        public double EmployeeTaxableIncome()
        {
            var taxable_Income = _taxGenerator.GetTaxableIncome(this.AnnualIncome);
            return taxable_Income;
        }

        public double EmployeeTax(double annualIncome)
        {
           return  _taxGenerator.GetPersonalIncomeTax(annualIncome);
        }
    }
}
