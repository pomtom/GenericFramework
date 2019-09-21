using Generic.Business.Service;
using Generic.Database.Poco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace Generic.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IEmployeeService _employeeservice;

        public ValuesController(IEmployeeService employeeservice)
        {
            this._employeeservice = employeeservice;
        }

        [HttpGet]
        public string Ping()
        {
            return string.Format("{0} - {1}, {2}", Environment.MachineName, Environment.UserDomainName, Environment.UserName);
        }

        [HttpGet]
        public string Fire()
        {
            using (StreamWriter _testData = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/data.txt"), true))
            {
                _testData.WriteLine("Hello i am here"); // Write the file.
            }
            return "Fire executed";
        }


        public IEnumerable<Employee> Get()
        {
            try
            {
                var response = _employeeservice.GetAllEmployee();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            return _employeeservice.GetEmployeeById(id);
        }

        // POST api/values
        public void Post([FromBody]Employee value)
        {
            _employeeservice.InsertEmployeeUsingSP(value);
        }

        // PUT api/values/5
        public void Put([FromBody]Employee value)
        {
            _employeeservice.UpdateEmployee(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _employeeservice.DeleteEmployee(id);
        }
    }
}
