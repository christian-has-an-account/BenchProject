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
    public class ReportingsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Reportings
        public IQueryable<Reporting> GetReportings()
        {
            return db.Reportings;
        }

        // GET: api/Reportings/5
        [ResponseType(typeof(Reporting))]
        public async Task<IHttpActionResult> GetReporting(int id)
        {
            Reporting reporting = await db.Reportings.FindAsync(id);
            if (reporting == null)
            {
                return NotFound();
            }

            return Ok(reporting);
        }

        // PUT: api/Reportings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReporting(int id, Reporting reporting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reporting.ReportingID)
            {
                return BadRequest();
            }

            db.Entry(reporting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportingExists(id))
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

        // POST: api/Reportings
        [ResponseType(typeof(Reporting))]
        public async Task<IHttpActionResult> PostReporting(Reporting reporting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reportings.Add(reporting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reporting.ReportingID }, reporting);
        }

        // DELETE: api/Reportings/5
        [ResponseType(typeof(Reporting))]
        public async Task<IHttpActionResult> DeleteReporting(int id)
        {
            Reporting reporting = await db.Reportings.FindAsync(id);
            if (reporting == null)
            {
                return NotFound();
            }

            db.Reportings.Remove(reporting);
            await db.SaveChangesAsync();

            return Ok(reporting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportingExists(int id)
        {
            return db.Reportings.Count(e => e.ReportingID == id) > 0;
        }
    }
}