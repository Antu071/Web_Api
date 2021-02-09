using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class ValuesController : ApiController
    {
        private Student_DatabaseEntities db = new Student_DatabaseEntities();
        // GET api/values
        public IEnumerable<Student> Get()
        {
            return (db.Students.ToList());
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
