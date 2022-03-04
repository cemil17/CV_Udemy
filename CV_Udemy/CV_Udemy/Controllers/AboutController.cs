using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Repositories;
using CV_Udemy.Models.Entity;
using System.IO;

namespace CV_Udemy.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin
        GenericRepository<TBL_About> repo = new GenericRepository<TBL_About>();
        [HttpGet]
        public ActionResult Index()
        {
            var about1 = repo.List();
            return View(about1);
        }
        [HttpPost]
        public ActionResult Index(TBL_About a)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                a.Image = "/image/" + fileName + extension;
            }
            var about = repo.Find(c => c.ID == 1);
            about.Name = a.Name;
            about.Surname = a.Surname;
            about.Address = a.Address;
            about.Mail = a.Mail;
            about.Phone = a.Phone;
            about.Description = a.Description;
            about.Image = a.Image;
            repo.TUpdate(about);
            return RedirectToAction("Index");
        }

    }
}