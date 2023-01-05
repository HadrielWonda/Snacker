using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Snacker.Api.Controllers;

    [Route("[controller]")]
    public class SnacksController : ApiController
    {
        private readonly ILogger<SnacksController> _logger;

        public SnacksController(ILogger<SnacksController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult ListSnacks()
        {
            return Ok(Array.Empty<string>());
        }

       /* [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }*/
    }
