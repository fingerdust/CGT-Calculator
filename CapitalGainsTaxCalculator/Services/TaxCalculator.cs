using System;
using System.Collections.Generic;

namespace CapitalGainsTaxCalculator.Services
{
    public class TaxCalculator
    {
        private const decimal TaxRate = 0.33m; // 33% capital gains tax rate

        public decimal CalculateTax(List<CapitalGain> capitalGains)
        {
            decimal totalTax = 0;

            foreach (var gain in capitalGains)
            {
                totalTax += CalculateGainTax(gain);
            }

            return totalTax;
        }

        private decimal CalculateGainTax(CapitalGain gain)
        {
            // Assuming the gain amount is the profit made
            return gain.Amount * TaxRate;
        }

        public decimal GetTaxRate()
        {
            return TaxRate;
        }
    }
}