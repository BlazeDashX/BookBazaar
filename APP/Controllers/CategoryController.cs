using BLL.Services;
using DAL.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService service = new CategoryService();

        public IActionResult Index()
        {
            var categories = service.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category c)
        {
            service.Create(c);
            return RedirectToAction("Index");
        }
    }
}
