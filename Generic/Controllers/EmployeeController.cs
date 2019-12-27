using Generic.Business.Service;
using Generic.Database.Poco;
using Generic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage GetAll()
        {
            try
            {
                var response = _employeeservice.GetAllEmployee();
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [BasicAuthentication]
        [Route("Employee/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                var response = _employeeservice.GetEmployeeById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);


            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [BasicAuthentication]
        [Route("Employee/Create")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            try
            {
                _employeeservice.InsertEmployeeUsingSP(value);
                var response = _employeeservice.GetAllEmployee();
                return Request.CreateResponse(HttpStatusCode.OK, response);
                
            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [BasicAuthentication]
        [Route("Employee/Update")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Employee value)
        {
            try
            {
                _employeeservice.UpdateEmployee(value);
                var response = _employeeservice.GetAllEmployee();
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [BasicAuthentication]
        [Route("Employee/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _employeeservice.DeleteEmployee(id);
                var response = _employeeservice.GetAllEmployee();
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [BasicAuthentication]
        [Route("postparam/{a}/{b}")]
        [HttpPost]
        public HttpResponseMessage PostParam(string a, string b)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, a + " " + b);
            }
            catch (System.Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}
