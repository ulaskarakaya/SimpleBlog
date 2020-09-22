using SimpleBlog.DAL.Context;
using SimpleBlog.Entity.Entities;
using SimpleBlog.Service.BaseServices.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Service.Services
{
    public class PostService:BaseServices<Post>
    {
        ProjectContext projectContext = new ProjectContext();
        public List<Post> GetPostByCategory(int categoryId)
        {
            return projectContext.Posts.Where(x => x.CategoryId == categoryId && x.Status != Status.Passive).ToList();
        }
    }
}
