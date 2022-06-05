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
    public class RocketsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //************************************* Listing all Rockets **********************


        // GET: api/RocketsData/ListRockets
        [HttpGet]
        public IEnumerable<RocketDto> ListRockets()
        {
            List<Rocket> Rockets = db.Rockets.ToList();
            List<RocketDto> RDto = new List<RocketDto>();

            Rockets.ForEach(r => RDto.Add(new RocketDto() 
            {
                RocketID = r.RocketID,
                RocketName = r.RocketName,
                RocketInfo = r.RocketInfo,
                SpaceAgencyID = r.SpaceAgency.SpaceAgencyID,
                SpaceAgencyName = r.SpaceAgency.SpaceAgencyName
            
            }));

            return RDto;
        }

        // *********************** Find a Rocket with given ID ************************************

        // GET: api/RocketsData/FindRocket/1
        [ResponseType(typeof(Rocket))]
        [HttpGet]
        public IHttpActionResult FindRocket(int id)
        {
            Rocket R = db.Rockets.Find(id);
            RocketDto RDto = new RocketDto()
            {
                RocketID = R.RocketID,
                RocketName = R.RocketName,
                RocketInfo = R.RocketInfo,
                SpaceAgencyID = R.SpaceAgency.SpaceAgencyID,
                SpaceAgencyName = R.SpaceAgency.SpaceAgencyName

            };

            if ( RDto == null)
            {
                return NotFound();
            }

            return Ok(RDto);
        }

        // ****************** list of rockets for given space agency ********************************

        // GET : api/RocketsData/ListRocketsForSpaceAgency/1
        [HttpGet]
        public IEnumerable<RocketDto> ListRocketsForSpaceAgency(int id)
        {
            List<Rocket> Rockets = db.Rockets.Where(r=>r.SpaceAgencyID==id).ToList();
            List<RocketDto> RDto = new List<RocketDto>();

            Rockets.ForEach(r => RDto.Add(new RocketDto()
            {
                RocketID = r.RocketID,
                RocketName = r.RocketName,
                RocketInfo = r.RocketInfo,
                SpaceAgencyID = r.SpaceAgency.SpaceAgencyID,
                SpaceAgencyName = r.SpaceAgency.SpaceAgencyName

            }));

            return RDto;
        }

        // **************************** Update a Rocket for a given ID ********************************

        // POST: api/RocketsData/UpdateRocket/1
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRocket(int id, Rocket rocket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rocket.RocketID)
            {
                return BadRequest();
            }

            db.Entry(rocket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RocketExists(id))
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



        // ******************************* Add a new Rocket ***************************************

        // POST: api/RocketsData/AddRocket
        [ResponseType(typeof(Rocket))]
        [HttpPost]
        public IHttpActionResult AddRocket(Rocket rocket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rockets.Add(rocket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rocket.RocketID }, rocket);
        }



        // ************************ Delete a Rocket with given ID *****************************s
        // DELETE: api/RocketsData/DeleteRocket/1
        [ResponseType(typeof(Rocket))]
        [HttpPost]
        public IHttpActionResult DeleteRocket(int id)
        {
            Rocket rocket = db.Rockets.Find(id);
            if (rocket == null)
            {
                return NotFound();
            }

            db.Rockets.Remove(rocket);
            db.SaveChanges();

            return Ok(rocket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RocketExists(int id)
        {
            return db.Rockets.Count(e => e.RocketID == id) > 0;
        }
    }
}