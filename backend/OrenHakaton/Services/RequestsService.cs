namespace OrenHakaton.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using NLog;
    using AutoMapper;
    using Newtonsoft.Json.Linq;

    using OrenHakaton.Models;
    using OrenHakaton.Models.DtoModels;

    public class RequestsService : IEntityService
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;
        private readonly IMapper _mapper;

        public RequestsService()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
            _context = new OrenHakatonContext();
        }

        public ActionResult<IEntityDto> Add(JObject jObject)
        {
            _logger.Trace("RequestsService Add");

            Requests requests = jObject.ToObject<Requests>();

            if (requests == null)
                return new NoContentResult();

            _context.Requests.Add(requests);
            _context.SaveChanges();

            return new OkResult();
        }

        public IEntityDto Get(JObject jObject)
        {
            _logger.Trace("RequestsService Get");

            RequestsDto requestsDto = jObject.ToObject<RequestsDto>();
            var dbUser = _context.Requests.FirstOrDefault(x => x.RequestId == requestsDto.RequestId);

             return _mapper.Map<Requests, RequestsDto>(dbUser);
        }

        public List<IEntityDto> GetAll()
        {
            _logger.Trace("RequestsService GetAll");

            var requests = _context.Requests.ToList();
            var entitiesDto = new List<IEntityDto>();
            var requestsDto =  _mapper.Map<List<Requests>, List<RequestsDto>>(requests);

            foreach (var item in requestsDto)
            {
                entitiesDto.Add(item);
            } 

            return entitiesDto;
        }
    }
}
