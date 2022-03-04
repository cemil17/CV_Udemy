using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CV_Udemy.Models.Entity;
using CV_Udemy.Repositories;

namespace CV_Udemy.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_Admin a)
        {
            CV_SiteEntities entities = new CV_SiteEntities();
            var userInfo = entities.TBL_Admin.FirstOrDefault(x => x.Username == a.Username && x.Password == a.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);
                Session["Username"] = userInfo.Username.ToString();
                return RedirectToAction("Index", "Admin2");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}