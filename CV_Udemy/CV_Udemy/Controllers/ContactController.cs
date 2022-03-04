using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Repositories;
using CV_Udemy.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace CV_Udemy.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TBL_Contact> repo = new GenericRepository<TBL_Contact>();
        public ActionResult Index(int number = 1)
        {
            var message = repo.List().OrderByDescending(x => x.ID).ToPagedList(number, 9);
            return View(message);
        }
    }
}