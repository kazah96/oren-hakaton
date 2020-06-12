namespace OrenHakaton.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "asdsad", "asdsad", "Mild", "Warm", "Balmy", "asdsaddsa", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var rng = new Random();
            var array = new List<string>();

            array.Add("asdsaddsa");

            return array;
        }
    }
}
