using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Database;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private CoreDBContext _context;

        public UserController(ILogger<UserController> logger, CoreDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _context.Users.ElementAt(id);
        }
        [HttpPost]
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
