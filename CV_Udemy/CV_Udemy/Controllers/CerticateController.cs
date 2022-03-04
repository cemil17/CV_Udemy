using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Models.Entity;
using CV_Udemy.Repositories;
using PagedList;
using PagedList.Mvc;

namespace CV_Udemy.Controllers
{
    public class CerticateController : Controller
    {
        // GET: Certicate
        GenericRepository<TBL_Certificate> repo = new GenericRepository<TBL_Certificate>();
        CV_SiteEntities entities = new CV_SiteEntities();
        public ActionResult Index(int number = 1)
        {
            var certificate = repo.List().ToPagedList(number,9);
            return View(certificate);
        }

        [HttpGet]
        public ActionResult CertificateGet(int id)
        {
            var certficate = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(certficate);
        }
        [HttpPost]
        public ActionResult CertificateGet(TBL_Certificate c)
        {
            var certficate = repo.Find(x => x.ID == c.ID);
            certficate.Certificate = c.Certificate;
            certficate.Number = c.Number;
            certficate.Datetime = c.Datetime;

            repo.TUpdate(certficate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CertificateNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CertificateNew(TBL_Certificate c)
        {
            if (!ModelState.IsValid)
            {
                return View("CertificateNew");
            }
            repo.TAdd(c);
            return RedirectToAction("Index");
        }
        public ActionResult CertificateRemove(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            repo.TDelete(certificate);
            return RedirectToAction("Index");
        }

        //public PartialViewResult MaxC()
        //{
        //    var max = entities.TBL_Certificate.Count().ToString();
        //    return PartialView(max);
        //}
    }
}