namespace OrenHakaton.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using NLog;
    using AutoMapper;
    using Newtonsoft.Json.Linq;

    using OrenHakaton.Models;
    using OrenHakaton.Models.DtoModels;
    using Microsoft.EntityFrameworkCore;

    public class HousesService : IEntityService
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;
        private readonly IMapper _mapper;

        public HousesService()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
            _context = new OrenHakatonContext();
        }

        public async Task<ActionResult<IEntityDto>> Add(JObject jObject)
        {
            _logger.Trace("HousesService Add");

            Houses requests = jObject.ToObject<Houses>();

            if (requests == null)
                return new NoContentResult();

            _context.Houses.Add(requests);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IEntityDto> Get(JObject jObject)
        {
            _logger.Trace("HousesService Get");

            HousesDto housesDto = jObject.ToObject<HousesDto>();
            var dbHouse = await _context.Houses.FirstOrDefaultAsync(x => x.HouseId == housesDto.HouseId);

             return _mapper.Map<Houses, HousesDto>(dbHouse);
        }

        public async Task<List<IEntityDto>> GetAll()
        {
            _logger.Trace("HousesService GetAll");

            var houses = await _context.Houses.ToListAsync();
            var entitiesDto = new List<IEntityDto>();
            var housesDto =  _mapper.Map<List<Houses>, List<HousesDto>>(houses);

            foreach (var item in housesDto)
            {
                entitiesDto.Add(item);
            } 

            return entitiesDto;
        }
    }
}
