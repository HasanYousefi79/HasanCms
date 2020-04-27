using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private MyCmsContext _db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(MyCmsContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if(where!=null)
            {
                query = query.Where(where);
            }

            if(orderby!=null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Update(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Delete(TEntity entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Delete(object id)
        {
            try
            {
                var item = GetById(id);
                Delete(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
