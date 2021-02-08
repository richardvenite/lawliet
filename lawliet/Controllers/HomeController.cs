using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace lawliet.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : Controller
    {
        // GET: View
        public ActionResult Index()
        {
            ViewBag.GitHub = "github.com/richardvenite";
            ViewBag.Title = "Lawliet";

            return View();
        }
    }
}