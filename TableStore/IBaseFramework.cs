using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TableStore
{

    public interface IBaseFramework
    {
        IEnumerable<Tbl> GetAll();
        //IEnumerable<Tbl<T>> FindByFunc(Expression<Func<T, bool>> predicate);
        void AddEntity(Tbl entity);
        void DeleteEntity(Tbl entity);
        void EditEntity(Tbl entity);
        void SaveEntity();
    }
}

