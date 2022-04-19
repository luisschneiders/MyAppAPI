using System;
using HealthCareAPI.Helpers;

namespace HealthCareAPI.Services
{
	public class LanguageService : ILanguageService
	{
        private static LanguageHelper _languageHelper { get; set; } = new();

        private string _uri { get; set; } = String.Empty;
        private bool _hasParameter { get; set; }

        public async Task<string> GetAsync(string parameter)
        {
            var x_rapidapi_host = Environment.GetEnvironmentVariable("X_RAPIDAPI_HOST");
            var x_rapidapi_key = Environment.GetEnvironmentVariable("X_RAPIDAPI_KEY");

            BuildURI(parameter);

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

        public void BuildURI(string parameter)
        {
            var endpoint = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ENDPOINT");
            var route = Environment.GetEnvironmentVariable("X_RAPIDAPI_TRANSLATOR_ROUTE");

            CheckParameter(parameter);

            _uri = _hasParameter ? $"{endpoint}{route}&scope={parameter}" : $"{endpoint}{route}";
        }

        public void CheckParameter(string parameter)
        {
            var scopes = _languageHelper.ListOfScopes();

            _hasParameter = parameter.Length > 0 && parameter != scopes[0];
        }
    }
}
