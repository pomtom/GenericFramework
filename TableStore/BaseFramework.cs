using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TableStore
{
    public class BaseFramework<T> : IBaseFramework
    {
        private readonly CloudTable mytable = null;


        public BaseFramework(string storagekey, string entityName)
        {
            var storageAccount = CloudStorageAccount.Parse(storagekey);
            var cloudTableClient = storageAccount.CreateCloudTableClient();
            mytable = cloudTableClient.GetTableReference(entityName);
            mytable.CreateIfNotExists();
        }


        public void AddEntity(T entity)
        {
            var operation = TableOperation.InsertOrReplace((Tbl)entity);
            mytable.Execute(operation);
        }

        public void DeleteEntity(Tbl entity)
        {
            var operation = TableOperation.Delete(entity);
            mytable.Execute(operation);
        }

        public void EditEntity(Tbl entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            mytable.Execute(operation);
        }

        //public IEnumerable<Tbl> FindByFunc(Expression<Func<T, bool>> predicate)
        //{
        //    IEnumerable<Tbl> query = _entities.Set<Tbl>()
        //        .Where(predicate);
        //    return query;
        //}

        public IEnumerable<Tbl> GetAll()
        {
            var query = new TableQuery<Tbl>();
            var entties = mytable.ExecuteQuery<Tbl>(query);
            return entties.ToList();
        }

        public void SaveEntity()
        {
            throw new NotImplementedException();
        }


    }
}
