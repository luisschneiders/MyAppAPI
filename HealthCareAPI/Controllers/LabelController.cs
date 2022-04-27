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
        public async Task<string> Post([FromBody] LabelMop labelMop)
        {
            return await _labelService.PostAsync(labelMop);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Byte[] b = System.IO.File.ReadAllBytes(@"./Labels/lfs_label_model_001.png");   // You can use your own method over here.         
            return File(b, "image/png");
        }
    }
}
