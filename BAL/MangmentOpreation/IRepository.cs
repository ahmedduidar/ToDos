using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BAL.MangmentOpreation
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(params object[] id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> IQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> IQueryable();
        T FindByEntity(Expression<Func<T, bool>> predicate);
        T FindByRelated(Expression<Func<T, bool>> predicate, string Navigation);
        IEnumerable<T> FindByListRelated(Expression<Func<T, bool>> predicate, string Navigation);
        bool Remove(T entity);
        bool Add(T entity);
        void AddRange(List<T> entity);
        void RemoveRange(List<T> entity);
        bool Update(T entity);
    }
}
