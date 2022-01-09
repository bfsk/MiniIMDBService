using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MiniIMDBService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IMDB : ControllerBase
    {


        private readonly ILogger<IMDB> _logger;

        public IMDB(ILogger<IMDB> logger)
        {
            _logger = logger;
        }
    }
}
