﻿using SimpleBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Map.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName("Status").IsRequired();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.UpdateDate).HasColumnName("UpdateDate").IsOptional();
            Property(x => x.DeleteDate).HasColumnName("DeleteDate").IsOptional();
        }
    }
}
