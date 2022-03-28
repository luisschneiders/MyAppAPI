using System;
using HealthCareAPI.Settings.Enum;

namespace HealthCareAPI.Services
{
	public class LanguageService
	{
        private static Language? _scope { get; set; } = Language.translation;

        public static async Task<string> GetAsync()
        {
            var endpoint = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ENDPOINT");
            var route = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ROUTE");

            var x_rapidapi_host = Environment.GetEnvironmentVariable("X_RAPIDAPI_HOST");
            var x_rapidapi_key = Environment.GetEnvironmentVariable("X_RAPIDAPI_KEY");

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri(endpoint + route + "&scope=" + _scope),

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
    }
}
