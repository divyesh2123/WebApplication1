using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (id.HasValue)
            {
                var category =  northwind3Context.Categories.Find(id);
                return PartialView("AddCategoryInfo",category);
            }
            else
            {
                return PartialView("AddCategoryInfo");
            }
        }

        [HttpPost]
        public JsonResult AddCategoryInfo(Category category)
        {
            if(category.CategoryId == 0)
            {
                var data = northwind3Context.Categories.Add(category);

            }
            else
            {
                var findCategroy = northwind3Context.Categories.Find(category.CategoryId);
                findCategroy.CategoryName = category.CategoryName;
                findCategroy.Description = category.Description;



            }
           
            northwind3Context.SaveChanges();
            return Json(new { result = true });
        }
    }
}
