using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SpaceSchedule.Models;

namespace SpaceSchedule.Controllers
{
    public class SpaceAgenciesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // ********************** List All Space Agencies **************************************

        // GET: api/SpaceAgenciesData/ListSpaceAgencies
        [HttpGet]
        public IQueryable<SpaceAgency> ListSpaceAgencies()
        {
            return db.SpaceAgencies;
        }

        // ********************* Find a Space Agency with given ID ***********************************

        // GET: api/SpaceAgenciesData/FindSpaceAgency/1
        [ResponseType(typeof(SpaceAgency))]
        [HttpGet]
        public IHttpActionResult FindSpaceAgency(int id)
        {
            SpaceAgency spaceAgency = db.SpaceAgencies.Find(id);
            if (spaceAgency == null)
            {
                return NotFound();
            }

            return Ok(spaceAgency);
        }


        //**************************** Update a Space Agency of given ID ***************************

        // POST: api/SpaceAgenciesData/UpdateSpaceAgency/1
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateSpaceAgency(int id, SpaceAgency spaceAgency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spaceAgency.SpaceAgencyID)
            {
                return BadRequest();
            }

            db.Entry(spaceAgency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceAgencyExists(id))
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


        //********************************* Add a new Space Agency ********************************

        // POST: api/SpaceAgenciesData/AddSpaceAgency
        [ResponseType(typeof(SpaceAgency))]
        public IHttpActionResult AddSpaceAgency(SpaceAgency spaceAgency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpaceAgencies.Add(spaceAgency);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spaceAgency.SpaceAgencyID }, spaceAgency);
        }


        // ****************************** Delete a Space Agency with given ID ***********************

        // DELETE: api/SpaceAgenciesData/DeleteSpaceAgency/1
        [ResponseType(typeof(SpaceAgency))]
        [HttpPost]
        public IHttpActionResult DeleteSpaceAgency(int id)
        {
            SpaceAgency spaceAgency = db.SpaceAgencies.Find(id);
            if (spaceAgency == null)
            {
                return NotFound();
            }

            db.SpaceAgencies.Remove(spaceAgency);
            db.SaveChanges();

            return Ok(spaceAgency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpaceAgencyExists(int id)
        {
            return db.SpaceAgencies.Count(e => e.SpaceAgencyID == id) > 0;
        }
    }
}