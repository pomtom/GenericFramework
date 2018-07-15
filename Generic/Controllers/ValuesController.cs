using Generic.Business.Service;
using System;
using System.Net;
using System.Net.Http;
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
        // GET api/values
        public HttpResponseMessage Get()
        {
            try
            {
                string response = _employeeservice.GetAllEmployee();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
