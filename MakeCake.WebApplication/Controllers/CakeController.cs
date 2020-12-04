using Hangfire;
using MakeCake.WebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCake.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly IMakeCakeService _makeCakeService;

        public CakeController(IMakeCakeService makeCakeService)
        {
            _makeCakeService = makeCakeService;
        }
        [HttpPost("MakeCake")]
        public IActionResult MakeCake()
        {
            var token = TokenGenerator.GenerateString(50);
            BackgroundJob.Enqueue(() => _makeCakeService.MakeCakeShortPolling(token).GetAwaiter().GetResult());
            return Ok(token);
        }
        [HttpGet("CheckState/{token}")]
        public IActionResult CakeState(string token)
        {
            return Ok(_makeCakeService.GetCakeState(token));
        }
        [HttpPost("MakeCakeLongPolling")]
        public async Task<IActionResult> MakeCakeLongPolling()
        {
            return Ok(await _makeCakeService.MakeCakeLongPolling());
        }
    }
}
