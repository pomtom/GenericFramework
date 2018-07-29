using Generic.Database.Poco;
using System.Collections.Generic;

namespace Generic.Database.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();

        void InsertEmployeeUsingSP(Employee emp);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee emp);

        void DeleteEmployee(int id);
    }
}
