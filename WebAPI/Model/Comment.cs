using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Comment
    {
        public string id { get; set; }

        public string content { get; set; }

        public int readBy { get; set; }
        public DateTime createTime { get; set; }
        public string url { get; set; }
    }
}
