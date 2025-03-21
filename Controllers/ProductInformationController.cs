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

        [HttpDelete]
        public JsonResult DeleteInfo(int id)
        {
            var data = northwind3Context.Categories.Find(id);
            northwind3Context.Categories.Remove(data);
            northwind3Context.SaveChanges();

            return Json(new { result=true });
        }

        [HttpGet]
        public PartialViewResult AddCategoryInfo(int? id)
        {
            return PartialView("AddCategoryInfo");
        }

        [HttpPost]
        public JsonResult AddCategoryInfo(Category category)
        {
            var data = northwind3Context.Categories.Add(category);
            northwind3Context.SaveChanges();
            return Json(new { result = true });
        }
    }
}
