using SimpleBlog.Entity.Entities;
using SimpleBlog.UI.Areas.Admin.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.UI.Areas.Admin.Data.VMs
{
    public class UpdatePostVM
    {
        public UpdatePostVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
            PostDTO = new PostDTO();
        }

        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public PostDTO PostDTO { get; set; }
    }
}