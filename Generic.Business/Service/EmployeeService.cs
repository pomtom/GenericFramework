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

        public void InsertEmployeeUsingSP(string emp)
        {
            //var employee = JsonConvert.DeserializeObject<Employee>(emp);
            Employee employee = new Employee();
            employee.Name = "Sachin";
            employee.Email = "sachin@gmail.com";
            employee.DOB = "10/09/1990";
            employee.Address = "Mumbai";
            _employeeRepository.InsertEmployeeUsingSP(employee);
        }
    }
}
