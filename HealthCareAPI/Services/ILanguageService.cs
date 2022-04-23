using System;
namespace HealthCareAPI.Services
{
    public interface ILanguageService
    {
        public Task<string> GetLanguagesAsync();

        public Task<string> GetLanguagesByScopeAsync(string parameter);

        public void BuildURI();

        public void BuildURIWithParameter(string parameter);

    }
}
