using System;
namespace HealthCareAPI.Services
{
    public interface ILanguageService
    {
        public Task<string> GetAsync(string parameter);

        public void BuildURI(string parameter);

        public void CheckParameter(string parameter);
    }
}

