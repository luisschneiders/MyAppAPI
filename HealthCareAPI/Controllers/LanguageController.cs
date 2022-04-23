using System;
using HealthCareAPI.Services;
using HealthCareAPI.Settings.Enum;
using HealthCareAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers
{
	[ApiController]
	[Route("/api/v1/[controller]")]
	public class LanguageController : Controller
	{

		private LanguageService _languageService { get; set; } = new();
		private AppSettings AppSettings { get; set; } = new();

        private string _scope { get; set; } = "";

		[HttpGet]
		public async Task<string> GetLanguageAsync()
		{

			var languages = await _languageService.GetLanguagesAsync();

			return languages;
		}

        [HttpGet("{id}")]
        public async Task<string> GetLanguageByScopeAsync(LanguageScope id)
        {
            _scope = AppSettings.BuildScope(id);

            var languages = await _languageService.GetLanguagesByScopeAsync(_scope);

            return languages;
        }
    }
}
