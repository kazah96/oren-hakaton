namespace OrenHakaton.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json.Linq;

    public interface IEntityService
    {
        Task<List<IEntityDto>> GetAll();

        Task<IEntityDto> Get(JObject jObject);

        Task<ActionResult<IEntityDto>> Add(JObject jObject);
    }
}
