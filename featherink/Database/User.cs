using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database
{
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        

    }
}
