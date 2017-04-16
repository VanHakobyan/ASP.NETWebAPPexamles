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
        static string[] fruit =
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
            if (id < fruit.Length)
            {
                return Request.CreateResponse(HttpStatusCode.OK, fruit[id]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Լուրջ մտածում էիր որ պետքա լինի?");
            }
        }
    }
}
