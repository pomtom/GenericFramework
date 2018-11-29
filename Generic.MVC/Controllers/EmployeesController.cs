using Generic.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Generic.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly string uri;
        public EmployeesController()
        {
            uri = ConfigurationManager.AppSettings["GENERIC-API-URL"];
        }


        // GET: Employees
        public async Task<ActionResult> Index()
        {
            List<Employee> employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    employee = JsonConvert.DeserializeObject<List<Employee>>(readTask.Result);

                    if (employee == null)
                    {
                        return View(employee);
                    }
                }
            }
            return View(employee);
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Employee employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var responseTask = client.GetAsync("Get/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    employee = JsonConvert.DeserializeObject<Employee>(readTask.Result);
                }
            }
            if (employee == null)
            {
                return View(employee);
            }

            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Age,BirthDate,Gender,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var jsonObject = JsonConvert.SerializeObject(employee);
                    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(uri);
                    var responseTask = client.PostAsync("Post", content);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Employee employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var responseTask = client.GetAsync("Get/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    employee = JsonConvert.DeserializeObject<Employee>(readTask.Result);
                }
            }
            if (employee == null)
            {
                return View(employee);
            }

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Age,BirthDate,Gender,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var jsonObject = JsonConvert.SerializeObject(employee);
                        var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                        client.BaseAddress = new Uri(uri);
                        var responseTask = client.PutAsync("Put", content);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return null;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var responseTask = client.DeleteAsync("Delete/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

    }
}
