using SimpleBlog.Entity.Entities;
using SimpleBlog.Service.Services;
using SimpleBlog.Utility.ImageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.UI.Controllers
{
    public class RegisterController : Controller
    {
        public AppUserService _appUserService;

        public RegisterController()
        {
            _appUserService = new AppUserService();
        }
        // GET: Register
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AppUser data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePath = new List<string>();
            UploadImagePath = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);
            data.UserImage = UploadImagePath[0];
            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImagePath;
                data.CruptedUserImage = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.XSmallUserImage = UploadImagePath[1];
                data.CruptedUserImage = UploadImagePath[2];
            }

            _appUserService.Add(data);
            return Redirect("/Account/Login");
        }
    }
}