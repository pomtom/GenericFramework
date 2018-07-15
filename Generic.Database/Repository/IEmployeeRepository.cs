using Generic.Database.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Database.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
    }
}
