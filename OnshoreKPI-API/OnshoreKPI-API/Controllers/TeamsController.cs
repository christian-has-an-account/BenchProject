﻿using System;
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
using System.Data.SqlClient;

namespace OnshoreKPI_API.Controllers
{
    public class TeamsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Teams
        public IQueryable<Team> GetTeams()
        {
            return db.Teams;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> GetTeam(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        //Get Teams of client by ClientID
        [HttpGet]
        [ResponseType(typeof(sp_GetAllTeamsByClient_Result))]
        public IHttpActionResult GetTeamByClientId(int CID)
        {
               var team =  db.sp_GetAllTeamsByClient(CID);
            {
                if(team == null)
                {
                    return NotFound();
                }
                return Ok(team);
            }
                
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeam(int id, Team team)  
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamID)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = team.TeamID }, team);
        }

        //// DELETE: api/Teams/5
        //[ResponseType(typeof(Team))]
        //public async Task<IHttpActionResult> DeleteTeam(int id)
        //{
        //    Team team = await db.Teams.FindAsync(id);
        //    if (team == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Teams.Remove(team);
        //    await db.SaveChangesAsync();

        //    return Ok(team);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.TeamID == id) > 0;
        }
    }
}