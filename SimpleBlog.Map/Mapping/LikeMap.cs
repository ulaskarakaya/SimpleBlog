﻿using SimpleBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Map.Mapping
{
   public class LikeMap:BaseMap<Like>
    {
        public LikeMap()
        {
            ToTable("dbo.Likes");

            HasRequired(x => x.Post)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
