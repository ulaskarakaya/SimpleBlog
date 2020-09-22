using SimpleBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Map.Mapping
{
    public class PostMap:BaseMap<Post>
    {
        public PostMap()
        {

            ToTable("dbo.Posts");
            Property(x => x.Content).IsRequired();
            Property(x => x.Header).IsRequired();

            HasRequired(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId);

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AppUserId);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Likes)
                .WithRequired(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);
        }
    }
}
