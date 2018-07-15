using Generic.Database.Poco;
using Generic.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Database.Repository
{
    public class EmployeeRepository : BaseRepository<GenericDbContext, Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployee()
        {
            var query = GetAll().ToList();
            return query;
        }
    }
}
