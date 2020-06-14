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

    public class MeetingService : IEntityService
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;
        private readonly IMapper _mapper;

        public MeetingService()
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
            _logger.Trace("MeetingService Add");

            Meetings requests = jObject.ToObject<Meetings>();

            if (requests == null)
                return new NoContentResult();

            _context.Meetings.Add(requests);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IEntityDto> Get(JObject jObject)
        {
            _logger.Trace("MeetingService Get");

            MeetingsDto requestsDto = jObject.ToObject<MeetingsDto>();
            var dbMeeting = await _context.Meetings.FirstOrDefaultAsync(x => x.PollId == requestsDto.PollId);

             return _mapper.Map<Meetings, MeetingsDto>(dbMeeting);
        }

        public async Task<List<IEntityDto>> GetAll()
        {
            _logger.Trace("MeetingService GetAll");

            var meetings = await _context.Meetings.ToListAsync();
            var entitiesDto = new List<IEntityDto>();
            var meetingsDto =  _mapper.Map<List<Meetings>, List<MeetingsDto>>(meetings);

            foreach (var item in meetingsDto)
            {
                entitiesDto.Add(item);
            } 

            return entitiesDto;
        }
    }
}
