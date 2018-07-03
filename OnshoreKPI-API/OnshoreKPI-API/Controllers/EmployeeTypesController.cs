using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnshoreKPI_API.Models;

namespace OnshoreKPI_API.Controllers
{
    public class EmployeeTypesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/EmployeeTypes
        public IQueryable<EmployeeType> GetEmployeeTypes()
        {
            return db.EmployeeTypes;
        }

        // GET: api/EmployeeTypes/5
        [ResponseType(typeof(EmployeeType))]
        public async Task<IHttpActionResult> GetEmployeeType(int id)
        {
            EmployeeType employeeType = await db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return NotFound();
            }

            return Ok(employeeType);
        }

        // PUT: api/EmployeeTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeType(int id, EmployeeType employeeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeType.TypeID)
            {
                return BadRequest();
            }

            db.Entry(employeeType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeeTypes
        [ResponseType(typeof(EmployeeType))]
        public async Task<IHttpActionResult> PostEmployeeType(EmployeeType employeeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeTypes.Add(employeeType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeType.TypeID }, employeeType);
        }

        // DELETE: api/EmployeeTypes/5
        [ResponseType(typeof(EmployeeType))]
        public async Task<IHttpActionResult> DeleteEmployeeType(int id)
        {
            EmployeeType employeeType = await db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return NotFound();
            }

            db.EmployeeTypes.Remove(employeeType);
            await db.SaveChangesAsync();

            return Ok(employeeType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeTypeExists(int id)
        {
            return db.EmployeeTypes.Count(e => e.TypeID == id) > 0;
        }
    }
}