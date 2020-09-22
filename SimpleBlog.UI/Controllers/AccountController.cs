using SimpleBlog.Entity.Entities;
using SimpleBlog.Service.Services;
using SimpleBlog.UI.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService _appUserRepo;

        public AccountController()
        {
            _appUserRepo = new AppUserService();
        }


        // GET: Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserRepo.FindByUserName(User.Identity.Name);

                if (user.Status != Status.Passive)
                {
                    if (user.Role == Role.Admin)
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Admin/Home/Index");
                    }
                    else if (user.Role == Role.Author)
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Author/Home/Index");
                    }
                    else
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Member/Home/Index");
                    }
                }
                else
                {
                    ViewData["error"] = "Username or Password are wrong..!";
                    return View();
                }
            }
            else
            {
                TempData["class"] = "custom-hide";
                return View();
            }

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credential)
        {
            if (ModelState.IsValid)
            {
                if (_appUserRepo.CheckCredentials(credential.UserName, credential.Password))
                {
                    AppUser user = _appUserRepo.FindByUserName(credential.UserName);
                    if (user.Status != Status.Passive)
                    {
                        if (user.Role == Role.Admin)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Admin/Home/Index");
                        }
                        else if (user.Role == Role.Author)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Author/Home/Index");
                        }
                        else if (user.Role == Role.Member)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Member/Home/Index");
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        ViewData["error"] = "Username or Password are wrong..!";
                        return View();
                    }
                }
                else
                {
                    ViewData["error"] = "Username or Password are wrong..!";
                    return View();
                }
            }
            else
            {
                TempData["class"] = "custom-hide";
                return View();
            }
        }

        [Authorize]//LOgin olmuş kullanıcı için 
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}