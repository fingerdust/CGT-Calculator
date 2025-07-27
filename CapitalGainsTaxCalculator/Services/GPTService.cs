using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace CapitalGainsTaxCalculator.Services
{
    public class GPTService
    {
        private readonly string _apiKey;
        private readonly string _resource;

        public GPTService(IOptions<ApiSettings> options)
        {
            _apiKey = options.Value.MyApiKey;
            _resource = options.Value.Resource;
        }

        public async Task<string> GetGgtValue(string request)
        {
            ChatClient client = new(model: "gpt-4.1", apiKey: _apiKey);
            ChatCompletion completion = client.CompleteChat($@"
                You are a helpful assistant that can analyze HTML and extract values.
                Here is the HTML content of a webpage:

                {_resource}

                Please find the value for the following request and return only a decimal value: {request}
                ");
            Console.WriteLine($"GPT >> {request} >> {completion.Content[0].Text}");
            return completion.Content[0].Text.Trim();
        }
    }
}