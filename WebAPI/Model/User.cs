using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class User
    {
        public static string hashPassword(string input)
        {
            SHA256 mySHA256 = SHA256.Create();
            byte[] result = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sBuilder.Append(result[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt => password!=null?hashPassword(password):null;
        public string email { get; set; }
        public string profile { get; set; }
        [ForeignKey("userid")]
        public List<Post> posts { get; set; }
    }
}
