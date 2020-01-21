using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class Post : PostUpdate
    {
        public int id { get; set; }
        public DateTime createdTime { get; set; }
        public int userid { get; set; }
    }
    public class PostUpdate : Tanggal
    {
        public string title { get; set; }
        public string content { get; set; }
        public string tags { get; set; }
        public string status { get; set; }
        //public DateTime updatedTime { get; set; }
        [ForeignKey("postid")]
        public List<Comment> comments { get; set; }
    }
    public class Tanggal
    {
        public DateTime updatedTime { get; set; }
    }
}
