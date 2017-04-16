using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OData.Models;

namespace OData.Controllers
{
    public class PeopleController : ApiController
    {
        [HttpGet]
   
        public IQueryable<People> AllPeople()
        {
            return Peoples.GetAll().AsQueryable();
        }
    }
}
