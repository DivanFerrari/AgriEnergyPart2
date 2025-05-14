using AgriFrontend.Model;
using AgriFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyFrontend.Controllers
{
    public class FarmerContoller : Controller
    {
        private readonly FarmerService _farmerService;

        public FarmerContoller(FarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        public async Task<IActionResult> Index()
        {
            List<Farmer> farmers = await _farmerService.GetAllFarmersAsync();
            return View(farmers);
        }
    }
}