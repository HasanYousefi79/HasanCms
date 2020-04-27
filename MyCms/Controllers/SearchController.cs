using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class SearchController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(db.MainActivity.SearchNews(q));
        }
    }
}