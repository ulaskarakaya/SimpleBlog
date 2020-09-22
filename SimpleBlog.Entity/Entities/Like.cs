using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Entity.Entities
{
    public class Like:BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
