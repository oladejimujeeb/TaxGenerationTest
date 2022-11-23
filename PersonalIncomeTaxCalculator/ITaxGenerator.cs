namespace PersonalIncomeTaxCalculator
{
    public interface ITaxGenerator
    {
        double GetPersonalIncomeTax(double taxableIncome);
        double GetTaxableIncome(double annualIncome);
       // double PersonalIncomeTax(double taxableIncome, double[] rates);
    }
}