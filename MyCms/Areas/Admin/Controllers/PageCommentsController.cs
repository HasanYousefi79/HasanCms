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
    public class PageCommentsController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/PageComments
        public ActionResult Index()
        {
            return View(db.PageCommentRepository.Get().OrderByDescending(c=> c.CreateDate));
        }

        // GET: Admin/PageComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageCommentRepository.GetById(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            return View(pageComment);
        }

        // GET: Admin/PageComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageCommentRepository.GetById(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            return View(pageComment);
        }

        // POST: Admin/PageComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.PageCommentRepository.Delete(id);
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
