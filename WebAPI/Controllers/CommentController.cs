using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private CoreDBContext _context;

        public CommentController(ILogger<CommentController> logger, CoreDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<Comment> GetAllComment()
        {
            return _context.Comments.ToList();
        }
        [HttpGet("{id}")]
        public Comment GetComment(int id)
        {
            return _context.Comments.ElementAt(id);
        }
        [HttpPost]
        public Comment AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
        [HttpPut("{id}")]
        public Comment UpdateComment(Comment comment, int id)
        {
            _context.Comments.Update(comment);
            //var create = _context.Users.Where(e => e.id == id).Single<User>();
            //create.username = user.username;
            _context.SaveChanges();
            var create = _context.Comments.ToList().ElementAt(id - 1);
            return create;
        }
        [HttpDelete("{id}")]
        public Comment RemoveComment(Comment comment, int id)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            var create = _context.Comments.ToList().ElementAt(id - 1);
            return create;
        }
    }
}
