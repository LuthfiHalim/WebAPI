using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return _context.Users.Include("posts.comments").Where(e => e.id == id).First<User>();
        }
        [HttpPost]
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        [HttpPut("{id}")]
        public User UpdateUser(User user, int id)
        {
            user.id = id;
            _context.Users.Update(user);
            //var create = _context.Users.Where(e => e.id == id).Single<User>();
            //create.username = user.username;
            _context.SaveChanges();
            var create = _context.Users.ToList().ElementAt(id - 1);
            return create;
        }
        [HttpDelete("{id}")]
        public User RemoveUser(User user, int id)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            var create = _context.Users.ToList().ElementAt(id - 1);
            return create;
        }
    }
}
