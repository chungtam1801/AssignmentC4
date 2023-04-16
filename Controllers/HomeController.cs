using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Assignment.IServices;
using Assignment.Services;
using Microsoft.AspNetCore.Routing;
using Assignment.ViewModels;
using Newtonsoft.Json;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClothesService _clothesService;
        private readonly IUserService _userService;
        private readonly IClothesDetailService _clothesDetailService;
        private readonly ICartDetailService _cartDetailService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IBillService _billService;
        private readonly IBillDetailService _billDetailService;
        private readonly ICartService _cartService;
        private readonly IRoleService _roleService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _clothesService = new ClothesService();
            _userService = new UserService();
            _clothesDetailService = new ClothesDetailService();
            _cartDetailService = new CartDetailService();
            _colorService = new ColorService();
            _sizeService = new SizeService();
            _billDetailService = new BillDetailService();
            _billService = new BillService();
            _cartService = new CartService();
            _roleService = new RoleService();
        }
        public IActionResult Index()
        {
            var clotheses = _clothesService.GetAllClothesView();
            return View(clotheses);
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
        [Route("ManageClothes")]
        public IActionResult ListClotheses()
        {
            var clotheses = _clothesService.GetAllClothes();
            return View(clotheses);
        }
        [Route("ShowClotheses")]
        public IActionResult ShowClotheses()
        {
            var clotheses = _clothesService.GetAllClothesView();
            return View(clotheses);
        }
        [Route("Detail")]
        public IActionResult Details(Guid id)
        {
            var clothesDetail = _clothesDetailService.GetClothesDetailById(id);
            var clothes = _clothesService.GetClothesById(clothesDetail.ClothesID);
            ViewBag.ListColor = _clothesService.GetColorClothes(clothesDetail.ClothesID);
            ViewBag.ListSize = _clothesService.GetSizeClothes(clothesDetail.ClothesID);
            HttpContext.Session.SetString("ClothesID", JsonConvert.SerializeObject(clothesDetail));
            return View(_clothesDetailService.GetClothesDetailVM(clothesDetail, clothes));
        }
        [Route("GetColor")]
        public IActionResult GetColor(Guid id)
        {
            ClothesDetail temp = JsonConvert.DeserializeObject<ClothesDetail>(HttpContext.Session.GetString("ClothesID"));
            var x = _clothesDetailService.GetClothesDetailByColorAndSize(id, temp.SizeID,temp.ClothesID);
            if (x == null || x.Quantity == 0)
            {
                return BadRequest();
            }
            return RedirectToAction("Details", new RouteValueDictionary(new
            {
                Controller = "Home",
                Action = "Details",
                id = x.ID
            }));
        }
        [Route("GetSize")]
        public IActionResult GetSize(Guid id)
        {
            ClothesDetail temp = JsonConvert.DeserializeObject<ClothesDetail>(HttpContext.Session.GetString("ClothesID"));
            var x = _clothesDetailService.GetClothesDetailByColorAndSize(temp.ColorID, id, temp.ClothesID);
            if (x == null || x.Quantity == 0)
            {
                return BadRequest();
            }
            return RedirectToAction("Details", new RouteValueDictionary(new
            {
                Controller = "Home",
                Action = "Details",
                id = x.ID
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListColor = _colorService.GetAllColor();
            ViewBag.ListSize = _sizeService.GetAllSize();
            return View();
            //Clothes c = new Clothes();
            //return PartialView("CreateClothes",c);
        }
        [HttpPost]
        public IActionResult Create(CreateClothesVM p, [Bind] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                p.clothes.ImamgeLocation = imageFile.FileName;
            }
            if (_clothesService.CreateClothes(p.clothes))
            {
                p.clothesDetail.ClothesID = p.clothes.ID;
                if (_clothesDetailService.CreateClothesDetail(p.clothesDetail))
                {
                    return RedirectToAction("ListClotheses");
                }
                else
                {
                    return BadRequest();
                }
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
        public IActionResult Edit(Clothes p,[Bind] IFormFile imageFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            p.ImamgeLocation = imageFile.FileName;
            if (_clothesService.UpdateClothes(p))
            {
                return RedirectToAction("ListClotheses");
            }
            else
            {
                return RedirectToAction("ListClotheses");
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
        [Route("RegisterView")]
        public IActionResult RegisterView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_userService.CreateUser(user))
            {
                return RedirectToAction("LoginView");
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("LoginView")]
        public IActionResult LoginView()
        {
            return View();
        }
        public IActionResult Login(User user)
        {
            var tempUser = _userService.Login(user.UserName, user.Password);
            if (tempUser != null)
            {
                HttpContext.Session.SetString("UserName", tempUser.UserID.ToString());
                HttpContext.Session.SetString("UserRole", _roleService.GetRoleById(tempUser.RoleID).RolenName);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("UserName", "");
            return RedirectToAction("Index");
        }
        //[Route("CreateClothesDetailView")]
        //public IActionResult CreateClothesDetail()
        //{
        //    return View();
        //}
        public IActionResult ListClothesDetail(Guid id)
        {
            var lst = _clothesDetailService.GetAllClothesDetail(id);
            HttpContext.Session.SetString("ClothesID", id.ToString());
            return View(lst);
        }
        [Route("CreateClothesDetail")]
        public IActionResult CreateClothesDetail()
        {
            ViewBag.ListColor = _colorService.GetAllColor();
            ViewBag.ListSize = _sizeService.GetAllSize();
            return View();
        }
        [HttpPost]
        public IActionResult CreateClothesDetails(ClothesDetail x)
        {
            x.ClothesID = new Guid(HttpContext.Session.GetString("ClothesID") ?? "");
            if (_clothesDetailService.CreateClothesDetail(x))
            {
                return RedirectToAction("ListClothesDetail", new RouteValueDictionary(new { Controller = "Home", Action = "ListClothesDetail", id = new Guid(HttpContext.Session.GetString("ClothesID") ?? "") }));
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("AddClothesToCart")]
        public IActionResult AddClothesToCart(Guid id)
        {
            string? x = HttpContext.Session.GetString("UserName");
            if (x == null)
            {
                return RedirectToAction("LoginView");
            }
            else
            {
                var cartDetail = new CartDetail();
                cartDetail.ClothesDetailID = id;
                cartDetail.UserID = new Guid(x);
                if(_cartDetailService.CreateCartDetail(cartDetail)) return RedirectToAction("Index");
                return BadRequest();
            }
        }
        [Route("BuyNow")]
        public IActionResult BuyNow(Guid id)
        {
            string? x = HttpContext.Session.GetString("UserName");
            if (x == null)
            {
                return RedirectToAction("LoginView");
            }
            else
            {
                var cartDetail = new CartDetail();
                cartDetail.ClothesDetailID = id;
                cartDetail.UserID = new Guid(x);
                if (_cartDetailService.CreateCartDetail(cartDetail)) return RedirectToAction("ShowCart");
                return BadRequest();
            }
        }
        [Route("ShowCart")]
        public IActionResult ShowCart()
        {
            string? x = HttpContext.Session.GetString("UserName");
            if (x == null)
            {
                return RedirectToAction("LoginView");
            }
            else
            {
                var cart = _cartDetailService.GetAllCartVM(new Guid(x));
                return View(cart);
            }
        }
        public IActionResult CreateColor()
        {
            Color c = new Color();
            return PartialView("CreateColor", c);
        }
        [HttpPost]
        public IActionResult CreateColor(Color x)
        {
            if (_colorService.CreateColor(x))
            {
                return RedirectToAction("CreateClothesDetail");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult CreateSize()
        {
            Size c = new Size();
            return PartialView("CreateSize", c);
        }
        [HttpPost]
        public IActionResult CreateSize(Size x)
        {
            if (_sizeService.CreateSize(x))
            {
                return RedirectToAction("CreateClothesDetail");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult CreateBill()
        {
            Bill bill = new Bill();
            bill.CreateDate = DateTime.Now;
            bill.UserID = new Guid(HttpContext.Session.GetString("UserName") ?? "");
            bill.Status = 1;
            if (!_billService.CreateBill(bill))
            {
                return BadRequest();
            }
            foreach (var x in _cartDetailService.GetAllCartVM(bill.UserID).ListClothes)
            {
                var y = new BillDetail();
                y.BillID = bill.ID;
                y.ClothesDetailID = x.ID;
                y.Quantity = x.Quantity;
                y.Price = x.Price;
                if (!_billDetailService.CreateBillDetail(y))
                {
                    return BadRequest();
                }
            }
            _cartService.DeleteCart(bill.UserID);
            return RedirectToAction("Index");
        }
        [Route("Chart")]
        public IActionResult Chart()
        {
            List<object> data = new List<object>();
            List<string> labels = _billService.GetBillChartVM().Select(x => x.CreateDate.ToString()).ToList();
            data.Add(labels);
            List<int> sumPrice = _billService.GetBillChartVM().Select(x => x.SumPrice).ToList();
            data.Add(sumPrice);
            return View();
        }
        public IActionResult ManageBill()
		{
            var lst = _billService.GetAllBill();
            return View(lst);
		}
        public IActionResult ListBillDetails(Guid id)
		{
            var lst = _billDetailService.GetAllBillDetail(id);
            return View(lst);
		}
        public IActionResult DeleteBill(Guid id)
		{
            var obj = _billService.GetBillById(id);
            obj.Status = 0;
            _billService.UpdateBill(obj);
            return RedirectToAction("ManageBill");
		}
        public IActionResult DoneBill(Guid id)
		{
            var obj = _billService.GetBillById(id);
            obj.Status = 2;
            _billService.UpdateBill(obj);
            return RedirectToAction("ManageBill");
		}
        public IActionResult SetDefaultClothesDetail(Guid id)
        {
            _clothesDetailService.SetDefaultClothesDetail(id);
            return RedirectToAction("ListClothesDetail", new RouteValueDictionary(new { Controller = "Home", Action = "ListClothesDetail", id = new Guid(HttpContext.Session.GetString("ClothesID") ?? "") }));
        }
    }
}