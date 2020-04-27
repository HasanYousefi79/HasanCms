using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MainActivity : IMainActivity
    {
        private MyCmsContext db;
        public MainActivity(MyCmsContext context)
        {
            db = context;
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<ShowGroupsViewModel> ShowGroups()
        {
            return db.PageGroups.Select(p => new ShowGroupsViewModel()
            {
                GroupId = p.GroupId,
                GroupTitle = p.GroupTitle,
                PageCount = p.Pages.Count
            });
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> SearchNews(string search)
        {
            return db.Pages.Where(p => p.Title.Contains(search) || p.ShortDescription.Contains(search) || p.Tags.Contains(search));
        }

        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogins.Any(u => u.UserName == username && u.Password == password);
        }
    }
}
