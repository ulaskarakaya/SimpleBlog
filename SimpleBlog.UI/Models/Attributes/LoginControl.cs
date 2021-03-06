﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.UI.Models.Attributes
{
    public class LoginControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("/Account/Login");
            }
        }
    }
}