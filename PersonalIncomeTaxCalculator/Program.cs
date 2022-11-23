using System;

namespace PersonalIncomeTaxCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var tax = new TaxGenerator();
            /* var t = tax.GetTaxableIncome(400000);
             Console.WriteLine(t);
             Console.WriteLine(tax.GetPersonalIncomeTax(t));
             var condition = new double[] { 300000, 500000, 500000, 1600000, 3200000};
             Console.WriteLine(tax.PersonalIncomeTax(t, condition));
             */
            ITaxGenerator taxGenerator = new TaxGenerator();
            Employee employee = new Employee(taxGenerator) { Name="Mujib Oladeji",AnnualIncome=4000000};
            var taxableIncome = employee.EmployeeTaxableIncome();
            var annualTax = employee.EmployeeTax(taxableIncome);

            Console.WriteLine($"Name:{employee.Name}\t TaxableIncome:{taxableIncome}" +
                $"\t Annual Income:{employee.AnnualIncome}" +
                $"\t Annual Tax Payable:{annualTax}");
        }
    }
}
