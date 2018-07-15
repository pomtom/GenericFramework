using Generic.Database.Poco;
using Generic.Database.Repository;
using Newtonsoft.Json;
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

        public string GetAllEmployee()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAllEmployee();
            string allemployee = JsonConvert.SerializeObject(employees);
            return allemployee;
        }
    }
}
