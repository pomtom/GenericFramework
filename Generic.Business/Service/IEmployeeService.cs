using Generic.Database.Poco;
using System.Collections.Generic;

namespace Generic.Business.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();

        void InsertEmployeeUsingSP(Employee emp);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee emp);

        void DeleteEmployee(int id);
    }
}
