using System;
using System.Linq;
using System.Linq.Expressions;

namespace Generic.Framework
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByFunc(Expression<Func<T, bool>> predicate);
        void AddEntity(T entity);
        void DeleteEntity(T entity);
        void EditEntity(T entity);
        void SaveEntity();
    }
}
