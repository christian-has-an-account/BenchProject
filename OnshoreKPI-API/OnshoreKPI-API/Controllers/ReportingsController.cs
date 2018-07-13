
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

        //GET: Get Reports by Employee's ID 
        [HttpGet]
        [ResponseType(typeof(sp_GetReportsByEmployeeID_Result))]
        public IHttpActionResult GetReportsByEmployeeID(int EID)
        {
            var user = db.sp_GetReportsByEmployeeID(EID);

            if (User == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
        
        //GET: Get Reports by date submitted
        [HttpGet]
        [ResponseType(typeof(sp_GetReportsByDate_Result))]
        public IHttpActionResult GetReportsByDate(string date)
        {
            var Date = Convert.ToDateTime(date);
            var user = db.sp_GetReportsByDate(Date);

            if (Date == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //GET: Get Reports On Client by ClientID
        [HttpGet]
        [ResponseType(typeof(sp_GetReportsByClient_Result))]
        public IHttpActionResult GetReportsByClient(int CID)
        {
            var user = db.sp_GetReportsByClient(CID);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //GET: Get Reports For Team X of Client Y
        [HttpGet]
        [ResponseType(typeof(sp_GetReportsByTeam_Result))]
        public IHttpActionResult GetReportsByTeam(int CID, int TID)
        {
            var user = db.sp_GetReportsByTeam(CID, TID);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //GET: Get Reports by Name associated 
        [HttpGet]
        [ResponseType(typeof(sp_GetReportsByName_Result))]
        public IHttpActionResult GetReportsByName(string Name)
        {
            var user = db.sp_GetReportsByName(Name);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Reports for Employee By Employee
        public IHttpActionResult GetReportsBySelf(string name)
        {
            var user = db.sp_GetReportsSelfSubmission(name);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //GET: Get Reports for one person submitted by another
        [HttpGet]
        [ResponseType(typeof(sp_GetReportsByProxySubmission_Result))]
        public IHttpActionResult GetReportsByProxy(string Name)
        {
            var user = db.sp_GetReportsByProxySubmission(Name);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Get Reports by Employee AND Date
        [HttpGet]                       
        [ResponseType(typeof(Reporting))]
        public IHttpActionResult GetReportsByEmployeeOnDate(int id, DateTime date)
        {
            var reports = db.sp_GetReportByDateandEmployee(id, date);

            if (reports == null)
            {
                return NotFound();
            }
            return Ok(reports);

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

        //// DELETE: api/Reportings/5
        //[ResponseType(typeof(Reporting))]
        //public async Task<IHttpActionResult> DeleteReporting(int id)
        //{
        //    Reporting reporting = await db.Reportings.FindAsync(id);
        //    if (reporting == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Reportings.Remove(reporting);
        //    await db.SaveChangesAsync();

        //    return Ok(reporting);
        //}

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