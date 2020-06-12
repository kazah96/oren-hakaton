namespace OrenHakaton.Controllers
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NLog;
    using OrenHakaton.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static readonly Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        private readonly OrenHakatonContext _context;

        public AuthController()
        {
            _context = new OrenHakatonContext();
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<List<Users>> Get()
        {
            logger.Trace("GetAllUsers called");

            return await _context.Users.ToListAsync();
        }

        [Route("AddUser")]
        [HttpPost]
        public ActionResult<Users> AddUser([FromBody] Users user)
        {
            logger.Trace("AddUser called");

            if (user == null)
                return NoContent();

            user.Password = GetHashedPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [Route("CheckAuthoriz")]
        [HttpPost]
        public async Task<Users> GetUser([FromBody] CheckUserDto user)
        {
            logger.Trace("CheckAuthoriz called");

            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Mail == user.Mail);

            if (dbUser == null)
                return null;

            if (dbUser.Password == GetHashedPassword(user.Password))
                return dbUser;

            return null;
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
