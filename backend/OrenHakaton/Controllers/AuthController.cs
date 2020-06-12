namespace OrenHakaton.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using OrenHakaton.Models;

    using NLog;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.Text;

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

        [HttpGet]
        public async Task<List<Users>> Get()
        {
            var qwe = new List<Users>();
            logger.Trace("Get users1");

            // Read
            logger.Trace("Get users2");

            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("AddUser")]
        [HttpPost]
        public ActionResult<Users> AddUser([FromBody] Users user)
        {
            logger.Trace("Add User");

            if (user == null)
                return NoContent();

            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(user.Password);
            var sha1data = sha1.ComputeHash(data);

            user.Password = System.Text.Encoding.Default.GetString(sha1data);

            // Create
            logger.Trace("Add User");
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [Route("CheckAuthoriz")]
        [HttpPost]
        public async Task<Users> GetUser([FromBody] CheckUser user)
        {
            logger.Trace("CheckUser");
            var sha1 = new SHA1CryptoServiceProvider();
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Mail == user.Mail);

            if (dbUser == null)
                return null;

            var data = Encoding.ASCII.GetBytes(user.Password);
            var sha1data = sha1.ComputeHash(data);
            var pass = System.Text.Encoding.Default.GetString(sha1data);

            if (dbUser.Password == pass)
                return dbUser;

            return null;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
