using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiSample.Controllers
{
    public class FruitController : ApiController
    {
        static List<string> fruit =new List<string>()
        {
            "Տանձ",
            "խնձոր",
            "Մանդարին",
            "Մնացածը պարզա !!!"
        };
        public IEnumerable<string> get()
        {
            return fruit;
        }
        //public string Get(int id)
        //{
        //    return fruit[id];
        //}
        public HttpResponseMessage Get(int id)
        {
            if (id < fruit.ToArray().Length)
            {
                return Request.CreateResponse(HttpStatusCode.OK, fruit[id]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Լուրջ մտածում էիր որ պետքա լինի?");
            }
        }
        public HttpResponseMessage Post([FromBody] string fruits)
        {
            fruit.Add(fruits);
            HttpResponseMessage ms = Request.CreateResponse(HttpStatusCode.Created, fruits);
            ms.Headers.Location = new Uri(Request.RequestUri + "/" + (fruit.Count - 1));
            return ms;
        }

        public HttpResponseMessage Put( int id, [FromBody] string value)
        {
            if (id > fruit.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                fruit[id] = value;
                return Request.CreateResponse(HttpStatusCode.OK, fruit[id]);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            if (id > fruit.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                string del = fruit[id];
                fruit.RemoveAt(id);
                return Request.CreateResponse(HttpStatusCode.OK, del);
            }
        }
        
    }
}
