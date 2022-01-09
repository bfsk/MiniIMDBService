using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniIMDBService.Services.ServiceInterfaces;
using MiniIMDBService.DL.Data.Views;
namespace MiniIMDBService.Controllers
{
    [ApiController]
    [Route("api/IMDB")]
    public class IMDBController : ControllerBase
    {

        //
        private readonly IExceptionLogger logger;
        private readonly ISearchIMDB searchService;

        public IMDBController(ISearchIMDB _SearchIMDB, IExceptionLogger _logger)
        {
            searchService = _SearchIMDB;
            logger = _logger;
        }

        [HttpGet("searchContent")]
        public async Task<ActionResult<TopContent>> searchDB([FromQuery] string query, [FromQuery] bool contentType, [FromQuery] int page)
        {
            try
            {
                var retVal = await searchService.GetByQuery(query, contentType, page);
                return Ok(retVal);
            }
            catch (Exception e)
            {
                logger.LogExcpeption("Exception at: " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception msg: " + e.Message);
                return BadRequest();
            }
        }
        [HttpGet("vote")]
        public async Task<ActionResult<TopContent>> Vote([FromQuery] int id, [FromQuery] float newScore, [FromQuery] bool contentType)
        {
            try
            {
                var retVal = await searchService.Vote(id, newScore, contentType);
                return Ok(retVal);
            }
            catch (Exception e)
            {
                logger.LogExcpeption("Exception at: " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception msg: " + e.Message);
                return BadRequest();
            }
        }
    }
}