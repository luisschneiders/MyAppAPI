using System;
using HealthCareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers
{
	[ApiController]
	[Route("/api/v1/[controller]")]
	public class LanguageController : Controller
	{
		[HttpGet(Name = "GetLanguages")]
		public async Task<string> GetAsync()
		{

			var languages = await LanguageService.GetAsync();

			return languages;
		}
	}
}

