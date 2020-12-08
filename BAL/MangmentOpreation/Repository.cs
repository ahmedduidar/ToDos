using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ToDoList.Models;

namespace BAL.MangmentOpreation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Update(T entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                entry.State = EntityState.Modified;

                _dbSet.Attach(entity);


            }
            return true;
        }

        public bool Add(T entity)
        {
            return _dbSet.Add(entity) == null ? false : true;
        }
        public void AddRange(List<T> entity)
        {
            _dbSet.AddRange(entity);
        }

        public IQueryable<T> IQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public IQueryable<T> IQueryable()
        {
            return _dbSet;
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T FindByEntity(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public T FindByRelated(Expression<Func<T, bool>> predicate, string NavigationProberty)
        {
            return _dbSet.Where(predicate).Include(NavigationProberty).FirstOrDefault();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(params object[] id)
        {
            return _dbSet.Find(id);
        }

        public bool Remove(T entity)
        {
            return _dbSet.Remove(entity) == null ? false : true;
        }
        public void RemoveRange(List<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
        public IEnumerable<T> FindByListRelated(Expression<Func<T, bool>> predicate, string Navigation)
        {
            return _dbSet.Where(predicate).Include(Navigation).ToList();
        }

    
    }
}
