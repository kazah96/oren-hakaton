namespace OrenHakaton.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json.Linq;

    public interface IEntityService
    {
        List<IEntityDto> GetAll();

        IEntityDto Get(JObject jObject);

        ActionResult<IEntityDto> Add(JObject jObject);
    }
}
