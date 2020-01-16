using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string tags { get; set; }
        public string status { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime updatedTime { get; set; }
        public int userid { get; set; }
        public List<Comment> comments { get; set; }
    }
}
