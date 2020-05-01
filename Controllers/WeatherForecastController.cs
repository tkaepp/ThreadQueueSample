using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ThreadQueueSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockingController : ControllerBase
    {
        [HttpGet("non50ms")]
        public async Task<IActionResult> NonBlockingTread50Ms()
        {
            await Task.Delay(50);

            return Ok();
        }
        
        [HttpGet("non500ms")]
        public async Task<IActionResult> NonBlockingTread500Ms()
        {
            await Task.Delay(500);

            return Ok();
        }

        [HttpGet("non")]
        public async Task<IActionResult> NonBlockingTread()
        {
            var rng = new Random();
            var timeout = rng.Next(50, 500);
            await Task.Delay(timeout);

            return Ok($"{timeout}");
        }

        [HttpGet("block")]
        public IActionResult BlockingThread()
        {
            var rng = new Random();
            var timeout = rng.Next(50, 500);
            Thread.Sleep(timeout);

            return Ok($"{timeout}");
        }


        [HttpGet("block50ms")]
        public IActionResult BlockingThread50ms()
        {
            Thread.Sleep(50);

            return Ok();
        }
        
        [HttpGet("block500ms")]
        public IActionResult BlockingThread500ms()
        {
            Task.Delay(500).Wait();
            
            return Ok();
        }
    }
}