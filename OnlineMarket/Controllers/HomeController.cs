using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Models;
using System.Diagnostics;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FileService _fileService;

        public HomeController(ILogger<HomeController> logger, FileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            IEnumerable<string> imgFiles = _fileService.GetFilesStartingWith("img", "LightBox");


            return View(imgFiles);
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
