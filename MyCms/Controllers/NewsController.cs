using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        public ActionResult ShowGroups()
        {
            return PartialView(db.MainActivity.ShowGroups());
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(db.PageGroupRepository.Get());
        }

        public ActionResult TopNews()
        {
            return PartialView(db.MainActivity.TopNews());
        }

        public ActionResult LastNews()
        {
            return PartialView(db.MainActivity.LastNews());
        }

        [Route("Archive")]
        public ActionResult Archive()
        {
            return View(db.PageRepository.Get());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id,string title)
        {
            ViewBag.name = title;
            return View(db.PageRepository.Get(p=> p.GroupId==id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = db.PageRepository.GetById(id);
            if(news == null)
            {
                return HttpNotFound();
            }
            news.Visit++;
            db.PageRepository.Update(news);
            db.Save();

            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageId = id,
                Comment = comment,
                Email = email,
                Name = name
            };
            db.PageCommentRepository.Insert(addcomment);
            db.Save();

            return PartialView("ShowComments", db.PageCommentRepository.Get(c=>c.PageId==id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(db.PageCommentRepository.Get(c => c.PageId == id));
        }
    }
}