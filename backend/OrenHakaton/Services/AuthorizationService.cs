namespace OrenHakaton.Controllers
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NLog;
    using AutoMapper;
    using Newtonsoft.Json.Linq;

    using OrenHakaton.Models;
    using OrenHakaton.Models.DtoModels;

    public class AuthorizationService : IEntityService
    {
        private static readonly Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;
        private readonly IMapper _mapper;

        public AuthorizationService()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _context = new OrenHakatonContext();
            _mapper = mappingConfig.CreateMapper();
        }

        public async Task<ActionResult<IEntityDto>> Add(JObject jObject)
        {
            _logger.Trace("AuthorizationService Add");

            Users users = jObject.ToObject<Users>();

            if (users == null)
                return new NoContentResult();

            //users.Password = GetHashedPassword(users.Password);

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IEntityDto> Get(JObject jObject)
        {
            _logger.Trace("AuthorizationService Get");

            UsersDto userDto = jObject.ToObject<UsersDto>();
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Mail == userDto.Mail);

            if (dbUser == null)
                return null;

            if (dbUser.Password == userDto.Password)//GetHashedPassword(userDto.Password))
                return _mapper.Map<Users, UsersDto>(dbUser);

            return null;
        }

        public async Task<List<IEntityDto>> GetAll()
        {
            _logger.Trace("AuthorizationService GetAll");

            var users = await _context.Users.ToListAsync();
            var entitiesDto = new List<IEntityDto>();
            var usersDto =  _mapper.Map<List<Users>, List<UsersDto>>(users);

            foreach (var item in usersDto)
            {
                entitiesDto.Add(item);
            } 

            return entitiesDto;
        }

        public string GetHashedPassword(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            var sha1data = sha1.ComputeHash(data);

            return Encoding.Default.GetString(sha1data);
        }
    }
}
