using FileUploader.WebService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FileUploader.WebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [HttpPost]
        public IActionResult UploadFile(IFormFile? uploadedFile)
        {
            if (uploadedFile == null) 
                return View("Index");

            var strings = ReadAsList(uploadedFile);

            ViewBag.Strings = strings;

            return View("Index");
        }

        public List<string> ReadAsList(IFormFile file)
        {
            var result = new List<string>();
            using var reader = new StreamReader(file.OpenReadStream());

            while (reader.Peek() >= 0)
                result.Add(reader.ReadLine());

            return result;
        }
    }
}