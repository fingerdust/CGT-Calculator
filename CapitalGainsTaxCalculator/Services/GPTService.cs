using System;
using Microsoft.Extensions.Options;

namespace CapitalGainsTaxCalculator.Services
{
    public class GPTService
    {
        private readonly string _apiKey;

        public GPTService(IOptions<ApiSettings> options)
        {
            _apiKey = options.Value.MyApiKey;
        }

        public void UseApi()
        {
            Console.WriteLine($"Using API key: {_apiKey}");
        }
    }
}