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
    public class RocketsController : Controller
    {
        // ************************ Code factoring ******************
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static RocketsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44390/api/");
        }

        // Displaying all Rockets in our database
        // GET: Rockets/List
        public ActionResult List()
        {
            string url = "RocketsData/ListRockets";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<RocketDto> Rockets = response.Content.ReadAsAsync<IEnumerable<RocketDto>>().Result;

            return View(Rockets);
        }

        // GET: Rockets/Details/5
        public ActionResult Details(int id)
        {
            DetailsRocket ViewModel = new DetailsRocket();

            // 1. getting details of rocket
            string url = "RocketsData/FindRocket/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            RocketDto Rocket = response.Content.ReadAsAsync<RocketDto>().Result;
            ViewModel.SelectedRocket = Rocket;

            // 2. getting list of lauches of rocket with given id
            url = "LaunchesData/ListLaunchForRocket/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<LaunchDto> Launches = response.Content.ReadAsAsync<IEnumerable<LaunchDto>>().Result;
            ViewModel.LaunchesByRocket = Launches;


            return View(ViewModel);
        }

        // *********************** Temp error page ********************
        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }

        // ************************** Adding a new Rocket ********************

        //GET Rockets/AddRocket
        [HttpGet]

        public ActionResult AddRocket()
        {
            string url = "SpaceAgenciesData/ListSpaceAgencies";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<SpaceAgency> SpaceAgencies = response.Content.ReadAsAsync<IEnumerable<SpaceAgency>>().Result;

            return View(SpaceAgencies);
        }

        // POST: Rockets/Add
        [HttpPost]
        public ActionResult Add(RocketDto rocket)
        {
            string url = "RocketsData/AddRocket";

            string jsonpayload = jss.Serialize(rocket);

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

        // *************************** Updating a Rocket with given id ***************************

        // GET: Rockets/EditPage/5
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            EditRocket ViewModel = new EditRocket();

            string url = "RocketsData/FindRocket/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            RocketDto rocket = response.Content.ReadAsAsync<RocketDto>().Result;
            ViewModel.editRocket = rocket;


            url = "SpaceAgenciesData/ListSpaceAgencies";
            response = client.GetAsync(url).Result;
            IEnumerable<SpaceAgency> spaceAgencies = response.Content.ReadAsAsync<IEnumerable<SpaceAgency>>().Result;
            ViewModel.editspaceAgencies = spaceAgencies;

            return View(ViewModel);
        }

        // POST: Rockets/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RocketDto rocket)
        {
            string url = "RocketsData/UpdateRocket/" + id;

            string jsonpayload = jss.Serialize(rocket);

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


        // ************** Deleteing a Rocket of given ID *****************************

        // GET: Rockets/DeletePage/5
        [HttpGet]
        public ActionResult DeletePage(int id)
        {
            string url = "RocketsData/FindRocket/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            RocketDto Rocket = response.Content.ReadAsAsync<RocketDto>().Result;

            return View(Rocket);
        }

        // POST: Rockets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            string url = "RocketsData/DeleteRocket/" + id;
            HttpContent content = new StringContent("");
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
    }
}
