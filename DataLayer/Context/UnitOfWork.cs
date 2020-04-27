using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IDisposable
    {
        MyCmsContext db = new MyCmsContext();

        private GenericRepository<Page> page;
        public GenericRepository<Page> PageRepository
        {
            get
            {
                if (page == null)
                {
                    page = new GenericRepository<Page>(db);
                }
                return page;
            }
        }

        private GenericRepository<PageComment> pageComment;
        public GenericRepository<PageComment> PageCommentRepository
        {
            get
            {
                if (pageComment == null)
                {
                    pageComment = new GenericRepository<PageComment>(db);
                }
                return pageComment;
            }
        }

        private GenericRepository<PageGroup> pageGroup;
        public GenericRepository<PageGroup> PageGroupRepository
        {
            get
            {
                if (pageGroup == null)
                {
                    pageGroup = new GenericRepository<PageGroup>(db);
                }
                return pageGroup;
            }
        }

        private GenericRepository<AdminLogin> admin;
        public GenericRepository<AdminLogin> AdminRepository
        { 
            get
            {
                if(admin==null)
                {
                    admin = new GenericRepository<AdminLogin>(db);
                }
                return admin;
            }
        }

        private IMainActivity mainActivity;
        public IMainActivity MainActivity
        {
            get
            {
                if(mainActivity==null)
                {
                    mainActivity = new MainActivity(db);
                }
                return mainActivity;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
