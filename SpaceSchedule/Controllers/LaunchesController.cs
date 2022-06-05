using SpaceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace SpaceSchedule.Controllers
{
    public class LaunchesController : Controller
    {
        // ************************ Code factoring ******************
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static LaunchesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44390/api/");
        }
        // ****************** Displaying all Launches in our database ******************
        // GET: Launches/List
        public ActionResult List()
        {
            string url = "LaunchesData/ListLaunches";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<LaunchDto> Launches = response.Content.ReadAsAsync<IEnumerable<LaunchDto>>().Result;

            return View(Launches);
        }

        // ******************* Displaying Detail of launch of given ID ******************
        // GET: Launches/Details/3
        public ActionResult Details(int id)
        {
            
            string url = "LaunchesData/FindLaunch/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            LaunchDto Launch = response.Content.ReadAsAsync<LaunchDto>().Result;
            
            return View(Launch);
        }

        // ************************* Temp Error page ***************

        public ActionResult Error()
        {
            return View();
        }

        // ******************** Adding new Launch *************************
        // GET: Launches/AddLaunch
        [HttpGet]
        public ActionResult AddLaunch()
        {
            string url = "RocketsData/ListRockets";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<RocketDto> Rockets = response.Content.ReadAsAsync<IEnumerable<RocketDto>>().Result;
            Debug.WriteLine("Option we are sending " + Rockets);

            return View(Rockets);
        }

        // POST: Launches/Add
        [HttpPost]
        public ActionResult Add(LaunchDto launch)
        {
            string url = "LaunchesData/AddLaunch";

            string jsonpayload = jss.Serialize(launch);
            Debug.WriteLine("JSON IS" + jsonpayload);
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

        // GET: Launches/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Launches/Edit/5
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

        // GET: Launches/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Launches/Delete/5
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
