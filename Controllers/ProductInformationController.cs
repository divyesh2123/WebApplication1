using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductInformationController : Controller
    {
        private Northwind3Context northwind3Context;
        public ProductInformationController()
        {
            northwind3Context = new Northwind3Context();
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var data = northwind3Context.Categories.ToList();

            return Json(new {data= data });  
        }
    }
}
