using Generic.Business.Service;
using Generic.Database.Poco;
using Generic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace Generic.Controllers
{
    [RoutePrefix("api/v1")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeservice;

        public EmployeeController(IEmployeeService employeeservice)
        {
            this._employeeservice = employeeservice;
        }

        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return string.Format("{0} - {1}, {2}", Environment.MachineName, Environment.UserDomainName, Environment.UserName);
        }

        [Route("fire")]
        [HttpGet]
        public string Fire()
        {
            using (StreamWriter _testData = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/data.txt"), true))
            {
                _testData.WriteLine("Hello i am here"); // Write the file.
            }
            return "Fire executed";
        }

        [BasicAuthentication]
        [Route("")]
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            try
            {
                var response = _employeeservice.GetAllEmployee();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [BasicAuthentication]
        [Route("Employee/{id}")]
        [HttpGet]
        public Employee Get(int id)
        {
            try
            {
                return _employeeservice.GetEmployeeById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [BasicAuthentication]
        [Route("Employee/Create")]
        [HttpPost]
        public void Post([FromBody]Employee value)
        {
            try
            {
                _employeeservice.InsertEmployeeUsingSP(value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [BasicAuthentication]
        [Route("Employee/Update")]
        [HttpPut]
        public void Put([FromBody]Employee value)
        {
            try
            {
                _employeeservice.UpdateEmployee(value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [BasicAuthentication]
        [Route("Employee/Delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                _employeeservice.DeleteEmployee(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
