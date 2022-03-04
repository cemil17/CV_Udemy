using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Udemy.Controllers
{
    public class TodoListController : Controller
    {
        // GET: TodoList
        public ActionResult Index()
        {
            return View();
        }
    }
}