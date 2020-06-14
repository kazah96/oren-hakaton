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

    public class EmployesService : IEntityService
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;
        private readonly IMapper _mapper;

        public EmployesService()
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
            _logger.Trace("EmployesService Add");

            EmployeesMC employeesMC = jObject.ToObject<EmployeesMC>();

            if (employeesMC == null)
                return new NoContentResult();

            _context.EmployeesMC.Add(employeesMC);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IEntityDto> Get(JObject jObject)
        {
            _logger.Trace("EmployesService Get");

            EmployeesMCDto employeesDto = jObject.ToObject<EmployeesMCDto>();
            var dbEmployees = await _context.EmployeesMC.FirstOrDefaultAsync(x => x.EmployeeId == employeesDto.EmployeeId);

             return _mapper.Map<EmployeesMC, EmployeesMCDto>(dbEmployees);
        }

        public async Task<List<IEntityDto>> GetAll()
        {
            _logger.Trace("EmployesService GetAll");

            var employees = await _context.EmployeesMC.ToListAsync();
            var entitiesDto = new List<IEntityDto>();
            var employeesDto =  _mapper.Map<List<EmployeesMC>, List<EmployeesMCDto>>(employees);

            foreach (var item in employeesDto)
            {
                entitiesDto.Add(item);
            } 

            return entitiesDto;
        }
    }
}
