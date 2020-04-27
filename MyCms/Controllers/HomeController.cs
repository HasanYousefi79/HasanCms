using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(db.MainActivity.PagesInSlider());
        }
    }
}