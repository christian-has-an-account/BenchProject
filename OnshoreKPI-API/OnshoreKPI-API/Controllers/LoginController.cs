using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnshoreKPI_API.Models;

namespace OnshoreKPI_API.Controllers
{
    public class LoginController : ApiController
    {
        private Entities db = new Entities();

        [HttpGet]
        [ResponseType(typeof(sp_GetEmployeeByEmail_Result))]
        public IHttpActionResult GetEmployeeByEmail(string Email)
        {
            var user = db.sp_GetEmployeeByEmail(Email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}