using SpaceSchedule.Models;
using SpaceSchedule.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SpaceSchedule.Controllers
{
    public class SpaceAgenciesController : Controller
    {
        // ******************************** Code factoring **********************
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static SpaceAgenciesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44390/api/");
        }
        
        // Displaying all Space agencies in our database
        // GET: SpaceAgencies/List
        public ActionResult List()
        {
            // request to api link : https://localhost:44390/api/SpaceAgenciesData/ListSpaceAgencies

            string url = "SpaceAgenciesData/ListSpaceAgencies";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<SpaceAgency> SpaceAgencies = response.Content.ReadAsAsync<IEnumerable<SpaceAgency>>().Result;

            return View(SpaceAgencies);
        }

        // GET: SpaceAgencies/Details/5
        public ActionResult Details(int id)
        {
            DetailsSpaceAgency ViewModel = new DetailsSpaceAgency();

            // Getting info for spaceAgency with given ID
            string url = "SpaceAgenciesData/FindSpaceAgency/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            SpaceAgency spaceAgency = response.Content.ReadAsAsync<SpaceAgency>().Result;
            ViewModel.SelectedSpaceAgency = spaceAgency;

            // Getting List Rockets developed by given SpaceAgency
            url = "RocketsData/ListRocketsForSpaceAgency/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<RocketDto> Rockets = response.Content.ReadAsAsync<IEnumerable<RocketDto>>().Result;
            ViewModel.RocketsBySpaceAgency = Rockets;
            return View(ViewModel);
        }

        // **************************** Temp Error Page *********************
        public ActionResult Error()
        {
            return View();
        }

        // ********************** Adding New Space Agency **************************

        // GET: SpaceAgencies/AddSpaceAgency
        [HttpGet]
        public ActionResult AddSpaceAgency()
        {
            return View();
        }

        // POST: SpaceAgencies/Create
        [HttpPost]
        public ActionResult Add(SpaceAgency spaceAgency)
        {
            string url = "SpaceAgenciesData/AddSpaceAgency";

            string jsonpayload = jss.Serialize(spaceAgency);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: SpaceAgencies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpaceAgencies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SpaceAgencies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpaceAgencies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
