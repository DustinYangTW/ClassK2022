using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        NorthwindEntities1 db =new NorthwindEntities1();
        // GET api/values
        public IEnumerable<Customers> Get()
        {
            var customers = db.Customers.ToList();
            return customers;
        }

        // GET api/values/5
        public string Get(string id)
        {
            var customers = db.Customers.Find(id);
            //只能是主鍵才可以用
            //customers = db.Customers.Where(c=>c.CustomerID == id).FirstOrDefault();
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
