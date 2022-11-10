using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SignUpForm_Backend.Models;
using System.Linq;

namespace SignUpForm_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")] 
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public readonly UserContext _context;
        public UserController(IConfiguration config, UserContext context)
        {
            configuration = config;
            _context = context;
        }
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if (_context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return Ok("Already Exist");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable=_context.Users.Where(u => u.Email == user.Email&& u.Pwd==user.Pwd).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok("Success");
            }
            return Ok("Failure");
        }
    }
}
