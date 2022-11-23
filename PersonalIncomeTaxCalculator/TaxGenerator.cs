using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalIncomeTaxCalculator
{
    public class TaxGenerator : ITaxGenerator
    {
        public const double PensionPercentage = 0.08;
        public const double ConsolidatedReliefRate = 0.20;
        public const double ConsolidatedRefliefAllowance = 200000;

        public double GetTaxableIncome(double grossIncome)
        {
            var pension = PensionPercentage * grossIncome;
            var netIncome = grossIncome - pension;
            var CRA1 = ConsolidatedReliefRate * netIncome;
            var CRA2 = 0.01 * grossIncome;
            if(ConsolidatedRefliefAllowance > CRA2)
            {
                return netIncome - CRA1 - ConsolidatedRefliefAllowance;
            }
           
            return netIncome - CRA1 - CRA2;
        }
        public double GetPersonalIncomeTax(double taxableIncome)
        {
            double tax = 0;
            double taxPercent = 0.07;
            if (taxableIncome < 300000)
            {
                return 0;
            }
            tax = taxPercent * 300000;
            taxableIncome -= tax;

            if (taxableIncome >= 300000)
            {
                taxPercent += 0.04;
                tax += taxPercent * 300000;
                taxableIncome -= tax;
            }
            if (taxableIncome >= 500000)
            {
                taxPercent += 0.04;
                tax += taxPercent * 500000;
                taxableIncome -= tax;
            }

            if (taxableIncome >= 500000)
            {
                taxPercent += 0.04;
                tax += taxPercent * 500000;
                taxableIncome -= tax;
            }

            if (taxableIncome >= 1600000)
            {
                taxPercent += 0.02;
                tax += taxPercent * 1600000;
                taxableIncome -= tax;
            }

            if(taxableIncome >= 3200000)
            {
                taxPercent += 0.03;
                tax += taxPercent * 3200000;
                taxableIncome -= tax;
            }

            else 
            {
                tax += 0.24 * taxableIncome;
            }
            return tax;
        }

       /* public double PersonalIncomeTax(double taxableIncome, double[] rates)
        {
            if (taxableIncome < 300000)
            {
                return 0;
            }
            double tax = 0;
            double taxPercent = 0.07;

            tax = taxPercent * 300000;
            taxableIncome -= tax;

            foreach (var rate in rates)
            {
                if (rate > taxableIncome)
                {
                    break;
                }
                else if (taxableIncome >= rate)
                {
                    if (rate <= 500000)
                    {
                        taxPercent += 0.04;
                        tax += taxPercent * rate;
                        taxableIncome -= tax;
                    }

                    else if (rate >= 1600000)
                    {
                        taxPercent += 0.02;
                        tax += taxPercent * 1600000;
                        taxableIncome -= tax;
                    }
                    else if (rate >= 3200000)
                    {
                        taxPercent += 0.03;
                        tax += taxPercent * 3200000;
                        taxableIncome -= tax;
                    }

                }

            }
            return tax;
        }*/
    }
}
