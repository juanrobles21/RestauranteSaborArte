using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ustaRestaurant.Data.Services;
using ustaRestaurant.Models;

namespace ustaRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _service;
        private readonly ICommentService _commentService;

        public HomeController(ILogger<HomeController> logger, IProductService service, ICommentService commentService)
        {
            _logger = logger;
            _service = service;
            _commentService = commentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(pt => pt.ProductType);
            ViewBag.Data = data;
            var dataComment = await _commentService.GetAllAsync();
            ViewBag.DataComment = dataComment;
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
    }
}