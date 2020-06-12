namespace OrenHakaton.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NLog;
    using OrenHakaton.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private static readonly Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;

        public RequestsController()
        {
            _context = new OrenHakatonContext();
        }

        [Route("GetAllRequests")]
        [HttpGet]
        public async Task<List<Requests>> Get()
        {
            logger.Trace("GetAllRequests called");

            return await _context.Requests.ToListAsync();
        }
    }
}
