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

    public class ManagementCompaniesService : IEntityService
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;
        private readonly IMapper _mapper;

        public ManagementCompaniesService()
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
            _logger.Trace("ManagementCompaniesService Add");

            ManagementCompanies requests = jObject.ToObject<ManagementCompanies>();

            if (requests == null)
                return new NoContentResult();

            _context.ManagementCompanies.Add(requests);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IEntityDto> Get(JObject jObject)
        {
            _logger.Trace("ManagementCompaniesService Get");

            ManagementCompaniesDto userDto = jObject.ToObject<ManagementCompaniesDto>();
            var dbUser = await _context.ManagementCompanies.FirstOrDefaultAsync(x => x.Mail == userDto.Mail);

            if (dbUser == null)
                return null;

            if (dbUser.Password == userDto.Password)//GetHashedPassword(userDto.Password))
                return _mapper.Map<ManagementCompanies, ManagementCompaniesDto>(dbUser);

            return null;
        }

        public async Task<List<IEntityDto>> GetAll()
        {
            _logger.Trace("ManagementCompaniesService GetAll");

            var requests = await _context.ManagementCompanies.ToListAsync();
            var entitiesDto = new List<IEntityDto>();
            var requestsDto =  _mapper.Map<List<ManagementCompanies>, List<ManagementCompaniesDto>>(requests);

            foreach (var item in requestsDto)
            {
                entitiesDto.Add(item);
            } 

            return entitiesDto;
        }
    }
}
