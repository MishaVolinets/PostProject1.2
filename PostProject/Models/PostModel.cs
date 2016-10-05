using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostProject.Models
{
    public class PostModel
    {
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}