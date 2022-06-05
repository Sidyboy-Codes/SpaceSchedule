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
    public class LaunchesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // ********************** List all Launches ********************************

        // GET: api/LaunchesData/ListLaunches
        [HttpGet]
        public IEnumerable<LaunchDto> ListLaunches()
        {
            List<Launch> Launches = db.Launches.ToList();
            List<LaunchDto> LDto = new List<LaunchDto>();

            Launches.ForEach(l => LDto.Add(new LaunchDto()
            {
               LaunchId = l.LaunchId,
               LaunchName = l.LaunchName,
               LaunchInfo = l.LaunchInfo,
               LaunchDate = l.LaunchDate,
               RocketID = l.Rocket.RocketID,
               RocketName = l.Rocket.RocketName
            }));

            return LDto;

        }

        // ********************** Getting info of launch of given launch ID ************

        // GET: api/LaunchesData/FindLaunch/1
        [HttpGet]
        [ResponseType(typeof(Launch))]
        public IHttpActionResult FindLaunch(int id)
        {
            Launch L = db.Launches.Find(id);
            LaunchDto LDto = new LaunchDto()
            {
                LaunchId = L.LaunchId,
                LaunchName = L.LaunchName,
                LaunchInfo = L.LaunchInfo,
                LaunchDate = L.LaunchDate,
                RocketID = L.Rocket.RocketID,
                RocketName = L.Rocket.RocketName

            };

            if (LDto == null)
            {
                return NotFound();
            }

            return Ok(LDto);
        }

        // **************** Listing lauches of given rocket id **********************

        // GET : api/LaunchesData/ListLaunchForRocket/1
        [HttpGet]
        public IEnumerable<LaunchDto> ListLaunchForRocket(int id)
        {
            List<Launch> Launches = db.Launches.Where(l=>l.RocketID==id).ToList();
            List<LaunchDto> LDto = new List<LaunchDto>();

            Launches.ForEach(l => LDto.Add(new LaunchDto()
            {
                LaunchId = l.LaunchId,
                LaunchName = l.LaunchName,
                LaunchInfo = l.LaunchInfo,
                LaunchDate = l.LaunchDate,
                RocketID = l.Rocket.RocketID,
                RocketName = l.Rocket.RocketName
            }));

            return LDto;

        }


        // ************************ Updating a launch of given ID *******************

        // POST: api/LaunchesData/UpdateLaunch/1
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateLaunch(int id, Launch launch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != launch.LaunchId)
            {
                return BadRequest();
            }

            db.Entry(launch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaunchExists(id))
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


        // ******************** Adding a new Launch ********************************


        // POST: api/LaunchesData/AddLaunch
        [HttpPost]
        [ResponseType(typeof(Launch))]
        public IHttpActionResult AddLaunch(Launch launch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Launches.Add(launch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = launch.LaunchId }, launch);
        }

        // ***************** Deleting a Launch of given Id ***************************

        // POST: api/LaunchesData/DeleteLaunch/1
        [HttpPost]
        [ResponseType(typeof(Launch))]
        public IHttpActionResult DeleteLaunch(int id)
        {
            Launch launch = db.Launches.Find(id);
            if (launch == null)
            {
                return NotFound();
            }

            db.Launches.Remove(launch);
            db.SaveChanges();

            return Ok(launch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaunchExists(int id)
        {
            return db.Launches.Count(e => e.LaunchId == id) > 0;
        }
    }
}