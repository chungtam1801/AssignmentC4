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
        public IActionResult Details(Guid id)
        {
            var clothes = _clothesService.GetClothesById(id);
            return View(clothes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Clothes p)
        {
            if(_clothesService.CreateClothes(p))
            {
                return RedirectToAction("ListClotheses");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var clothes = _clothesService.GetClothesById(id);
            return View(clothes);
        }
        public IActionResult Edit(Clothes p)
        {
            if (_clothesService.UpdateClothes(p))
            {
                return RedirectToAction("ListClotheses");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (_clothesService.DeleteClothes(id))
            {
                return RedirectToAction("ListClotheses");
            }
            else
            {
                return View("Index");
            }
        }
    }
}