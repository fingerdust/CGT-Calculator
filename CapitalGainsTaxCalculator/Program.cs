using System;
using System.Collections.Generic;
using System.Globalization;
using CapitalGainsTaxCalculator.Services;
using CapitalGainsTaxCalculator.Utils;

namespace CapitalGainsTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Capital Gains Tax Calculator!");

            List<CapitalGain> capitalGains = new List<CapitalGain>();
            InputParser inputParser = new InputParser();
            TaxCalculator taxCalculator = new TaxCalculator();

            while (true)
            {
                // Will take a file next
                Console.WriteLine("Please enter a capital gain transaction (or type 'exit' to finish):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    CapitalGain capitalGain = inputParser.ParseCapitalGainInput(input);
                    capitalGains.Add(capitalGain);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing input: {ex.Message}");
                }
            }

            decimal totalTaxOwed = taxCalculator.CalculateTax(capitalGains);
            Console.WriteLine($"Total Capital Gains Tax Owed: {totalTaxOwed.ToString("C", new CultureInfo("en-IE"))}");
        }
    }
}