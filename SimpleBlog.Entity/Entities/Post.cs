using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Entity.Entities
{
    public class Post:BaseEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
