using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnshoreKPI_API.Controllers
{
    public class ExampleController1 : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            //will be used AUTOMATTICALLY for any get that DOES NOT have a specific get function related to it,
                //as long as it involves a "~/Example" url (a get all pull perhaps?)
            return new string[] { "", "" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            //Will be AUTOMATTICALLY used for any GET function on "~/example/{id#}" url('s)
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            //Using [From Body] to automatically breakdown the JSON we are posting into the pieces the computer is expecting.
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            //will be used for any UPDATE function of the Example onject not using a specific update function on its own.
            //[From Body} tag filling the same function as above
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //...Kinda Obvious right?
        }
    }
}