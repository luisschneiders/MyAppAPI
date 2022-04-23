using System;
using HealthCareAPI.Helpers;

namespace HealthCareAPI.Services
{
	public class LanguageService : ILanguageService
	{

        private string _uri { get; set; } = String.Empty;

        public async Task<string> GetLanguagesAsync()
        {
            var x_rapidapi_host = Environment.GetEnvironmentVariable("X_RAPIDAPI_HOST");
            var x_rapidapi_key = Environment.GetEnvironmentVariable("X_RAPIDAPI_KEY");

            BuildURI();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri(_uri),

                Headers =
                {
                    { "x-rapidapi-host", x_rapidapi_host },
                    { "x-rapidapi-key", x_rapidapi_key },
                },
            };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            return body;
        }

        public async Task<string> GetLanguagesByScopeAsync(string parameter)
        {
            var x_rapidapi_host = Environment.GetEnvironmentVariable("X_RAPIDAPI_HOST");
            var x_rapidapi_key = Environment.GetEnvironmentVariable("X_RAPIDAPI_KEY");

            BuildURIWithParameter(parameter);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri(_uri),

                Headers =
                {
                    { "x-rapidapi-host", x_rapidapi_host },
                    { "x-rapidapi-key", x_rapidapi_key },
                },
            };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            return body;
        }

        public void BuildURI()
        {
            var endpoint = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ENDPOINT");
            var route = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ROUTE");

            _uri = $"{endpoint}{route}";
        }

        public void BuildURIWithParameter(string parameter)
        {
            var endpoint = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ENDPOINT");
            var route = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ROUTE");


            _uri = $"{endpoint}{route}&scope={parameter}";
        }
    }
}
