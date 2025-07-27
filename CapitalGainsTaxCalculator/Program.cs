using System;
using System.Collections.Generic;
using System.Globalization;
using CapitalGainsTaxCalculator.Services;
using CapitalGainsTaxCalculator.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CapitalGainsTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up dependency injection and configuration
            var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<ApiSettings>(context.Configuration.GetSection("ApiSettings"));
                services.AddTransient<GPTService>();
            })
            .Build();

            var service = host.Services.GetRequiredService<GPTService>();
            service.UseApi();


            Console.WriteLine("Welcome to the Capital Gains Tax Calculator!");

            Console.WriteLine("The current capital gains tax rate: ");

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