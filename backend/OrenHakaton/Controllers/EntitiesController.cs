namespace OrenHakaton.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Cors;

    using NLog;
    using Unity;
    using Newtonsoft.Json.Linq;

    using OrenHakaton.App_Start;

    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        [EnableCors("MyPolicy")]
        [Route("GetAll/{entity}")]
        [HttpGet]
        public Task<List<IEntityDto>> GetAll([FromRoute] string entity)
        {
            _logger.Trace("GetAll called");

            var service = UnityConfig._unityContainer.Resolve<IEntityService>(entity.ToLower());
            var r = service.GetAll();
            
            return r;
        }

        [EnableCors("MyPolicy")]
        [Route("Add/{entity}")]
        [HttpPost]
        public Task<ActionResult<IEntityDto>> Add([FromRoute] string entity, [FromBody] JObject jObject)
        {
            _logger.Trace("Add called");

            var service = UnityConfig._unityContainer.Resolve<IEntityService>(entity.ToLower());
            var r = service.Add(jObject);

            return r;
        }

        [EnableCors("MyPolicy")]
        [Route("Get/{entity}")]
        [HttpPost]
        public Task<IEntityDto> Get([FromRoute] string entity, [FromBody] JObject jObject)
        {
            _logger.Trace("Get called");

            var service = UnityConfig._unityContainer.Resolve<IEntityService>(entity.ToLower());
            var r = service.Get(jObject);

            return r;
        }
    }
}
