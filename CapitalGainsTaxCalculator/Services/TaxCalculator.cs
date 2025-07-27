using System.Collections.Generic;

namespace CapitalGainsTaxCalculator.Services
{
    public class TaxCalculator
    {
        public decimal CalculateTax(List<CapitalGain> capitalGains, decimal taxRate)
        {
            decimal totalTax = 0;

            foreach (var gain in capitalGains)
            {
                totalTax += CalculateGainTax(gain, taxRate);
            }

            return totalTax;
        }

        private decimal CalculateGainTax(CapitalGain gain, decimal taxRate)
        {
            // Assuming the gain amount is the profit made
            return gain.Amount * taxRate;
        }
    }
}