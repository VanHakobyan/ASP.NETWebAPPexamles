using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        static readonly IEmployeeRepository repository = new EmployeeRepository();
        public IEnumerable<Employee> GetAllEmployee()
        {
            return repository.GetAll();
        }
        public Employee GetEmployee(int id)
        {
            Employee item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return item;
        }
        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostEmployee(Employee item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutEmployee(int id, Employee employee)
        {
            employee.Id = id;
            if (!repository.Update(employee))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
        public HttpResponseMessage DeleteEmployee(int id)
        {
            repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
