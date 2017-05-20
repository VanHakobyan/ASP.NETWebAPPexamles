using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiManipilation.Models;

namespace WebApiManipilation.Controllers
{
    public class CustomController : ApiController
    {
        List<Person> list = new List<Person>
        {
            new Person{ID=0,Name="Messi"},
            new Person{ID=1,Name="Pique"}
        };
        // GET: api/Custom
        public IEnumerable<Person> Get()
        {
            return list;
        }

        // GET: api/Custom/5
        public Person Get(int id)
        {
            return list[id];
        }

        // POST: api/Custom
        public HttpResponseMessage Post(int id, string name)
        {
            Person persons = new Person { ID = id, Name = name };
            list.Add(persons);
            var response = Request.CreateResponse(HttpStatusCode.Created, persons);
            //response.Headers.Location = new Uri(Request.RequestUri + "/" + (list.Count - 1));

            return response;
        }

        // PUT: api/Custom/5
        public HttpResponseMessage Put(int id, string value)
        {
            if (id < list.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                list[id].Name = value;
                return Request.CreateResponse(HttpStatusCode.OK, list[id]);
            }
        }

        // DELETE: api/Custom/5
        public HttpResponseMessage Delete(int id)
        {
            if (!list.Contains(list[id]))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            else
            {
                list.RemoveAt(id);
                string deleted = list[id].Name;
                return Request.CreateResponse(HttpStatusCode.OK, deleted);

            }
        }
    }
}
