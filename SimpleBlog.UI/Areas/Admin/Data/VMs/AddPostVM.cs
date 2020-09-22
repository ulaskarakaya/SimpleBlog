using SimpleBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.UI.Areas.Admin.Data.VMs
{
    public class AddPostVM
    {
        public AddPostVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
        }

        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}