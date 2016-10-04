using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}