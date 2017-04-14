using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleAPP.Models;
namespace SimpleAPP.Controlers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {

        [Route("values")]
        [HttpGet]
        public IHttpActionResult GetValues()
        {
            var resulit = new string[]
            {
                "Ախ ոտս",
                "Տեղ տուր նստեմ"
            };
            return Ok(resulit);
        }

        [Route("values")]
        [HttpPost]
        public IHttpActionResult SendValues(Person model)
        {
            if (model==null)
            {
                return BadRequest();
            }
            model.Age++;
            model.Name += "!";
            return Ok(model);
        }
        //Get Chrome extensin Postman
    }
}
