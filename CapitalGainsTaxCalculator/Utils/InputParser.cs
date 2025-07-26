using System;

namespace CapitalGainsTaxCalculator.Utils
{
    public class InputParser
    {
        public CapitalGain ParseCapitalGainInput(string input)
        {
            var parts = input.Split(',');

            if (parts.Length != 3)
            {
                throw new ArgumentException("Input must contain exactly three parts: Amount, Date, and Type.");
            }

            if (!decimal.TryParse(parts[0].Trim(), out decimal amount))
            {
                throw new ArgumentException("Invalid amount format.");
            }

            if (!DateTime.TryParse(parts[1].Trim(), out DateTime date))
            {
                throw new ArgumentException("Invalid date format.");
            }

            var type = parts[2].Trim();

            return new CapitalGain(amount, date, type);
        }
    }
}
