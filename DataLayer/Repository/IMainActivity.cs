using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMainActivity
    {
        IEnumerable<ShowGroupsViewModel> ShowGroups();
        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> SearchNews(string search);
        bool IsExistUser(string username, string password);
    }
}
