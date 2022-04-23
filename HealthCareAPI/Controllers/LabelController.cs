using System;
using HealthCareAPI.Services;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]s")]
    public class LabelController : ControllerBase
    {
        private LabelService _labelService { get; set; } = new();

        [HttpPost]
        public async Task<string> CreateLabelPost([FromBody] LabelMop labelMop)
        {
            return await _labelService.PostAsync(labelMop);
        }
    }
}
