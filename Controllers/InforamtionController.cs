using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class InforamtionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TempData["Test"] = "This is the information";
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutUsInfo()
        {
            return View();
        }
    }
}
