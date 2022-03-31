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

		[HttpGet(Name = "GetLanguages")]
		public async Task<string> GetAsync([FromQuery] LanguageScope scope)
		{
			_scope = AppSettings.BuildScope(scope);

			var languages = await _languageService.GetAsync(_scope);

			return languages;
		}
	}
}
