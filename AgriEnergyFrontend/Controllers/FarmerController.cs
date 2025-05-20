using AgriEnergyFrontend.Model;
using AgriEnergyFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;
using static System.Net.WebRequestMethods;

namespace AgriEnergyFrontend.Controllers
{
    //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
    //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
    //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].

    public class FarmerController : Controller
    {
        private readonly FarmerService _farmerService;
        private readonly HttpClient _client;

        public FarmerController(FarmerService farmerService, HttpClient client)
        {
            _farmerService = farmerService;
            _client = client;
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].

        public async Task<IActionResult> Index()
        {
            List<Farmer> farmers = await _farmerService.GetAllFarmersAsync();
            return View(farmers);
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].


        [HttpPost]
        public IActionResult Create(Farmer model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.PostAsync("http://api-service:8080/api/farmer", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error:" + ex.Message);
            }

            return View(model);
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].


        //Code Semantic(2023). 29 - Consume DELETE Request In MVC | 
        //ASP.net Web API. [online] YouTube.Available at: https://www.youtube.com/watch?v=CPFTOOU8sBc [Accessed 18 May 2025].
        public IActionResult Delete(int id) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api-service:8080/api/farmer");

            var deleteTask = client.DeleteAsync("farmer/" + id);
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Code Semantic(2023). 29 - Consume DELETE Request In MVC | 
        //ASP.net Web API. [online] YouTube.Available at: https://www.youtube.com/watch?v=CPFTOOU8sBc [Accessed 18 May 2025].

    }
}