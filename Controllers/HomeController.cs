using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Assignment.IServices;
using Assignment.Services;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClothesService _clothesService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _clothesService = new ClothesService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ListClotheses()
        {
            var clotheses = _clothesService.GetAllClothes();
            return View(clotheses);
        }
    }
}