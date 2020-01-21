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
    [Route("post")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private CoreDBContext _context;

        public PostController(ILogger<PostController> logger, CoreDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<Post> GetAllPost()
        {
            return _context.Posts.ToList();
        }
        [HttpGet("{id}")]
        public Post GetPost(int id)
        {
            return _context.Posts.Include("Comments").ElementAt(id);
        }
        [HttpPost]
        public Post AddPost(Post post)
        {
            //Post anak = new Post()
            //{
            //    comments = post.comments;
                
            //}
            //_context.Posts.Add(bapak);
            //_context.SaveChanges();
            return post;
        }
        [HttpPut("{id}")]
        public Post UpdatePost(Post post, int id)
        {
            _context.Posts.Update(post);
            //var create = _context.Users.Where(e => e.id == id).Single<User>();
            //create.username = user.username;
            _context.SaveChanges();
            var create = _context.Posts.ToList().ElementAt(id - 1);
            return create;
        }
        [HttpDelete("{id}")]
        public Post RemovePost(Post post, int id)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
            var create = _context.Posts.ToList().ElementAt(id - 1);
            return create;
        }
    }
}
