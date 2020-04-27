using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms.Areas.Admin.Controllers
{
    public class AdminLoginsController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/AdminLogins
        public ActionResult Index()
        {
            return View(db.AdminRepository.Get());
        }

        // GET: Admin/AdminLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminRepository.GetById(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // GET: Admin/AdminLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginID,UserName,Email,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.AdminRepository.Insert(adminLogin);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(adminLogin);
        }

        // GET: Admin/AdminLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminRepository.GetById(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: Admin/AdminLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginID,UserName,Email,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.AdminRepository.Update(adminLogin);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(adminLogin);
        }

        // GET: Admin/AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminRepository.GetById(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: Admin/AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogin adminLogin = db.AdminRepository.GetById(id);
            db.AdminRepository.Delete(adminLogin);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
