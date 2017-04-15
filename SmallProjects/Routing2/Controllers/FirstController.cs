using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing2.Controllers
{
    public class FirstController : ApiController
    {
        [HttpGet]
        public string SayHi()
        {
            return "hi";
        }

    }
}
