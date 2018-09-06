using Generic.Database.Poco;
using Generic.Database.Repository;
using System.Collections.Generic;

namespace Generic.Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }


        public IEnumerable<Employee> GetAllEmployee()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAllEmployee();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return employee;
        }

        public void InsertEmployeeUsingSP(Employee employee)
        {
            _employeeRepository.InsertEmployeeUsingEE(employee);
        }

        public void UpdateEmployee(Employee emp)
        {
            _employeeRepository.UpdateEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
    }
}
