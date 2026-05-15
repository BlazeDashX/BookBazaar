using Microsoft.AspNetCore.Mvc;
using BLL.DTOs;
using BLL.Services;

namespace APP.Controllers
{
    public class AdminBookController : Controller
    {
        private readonly BookService service = new BookService();

        public IActionResult Create()
        {
            var categories = new CategoryService().GetAll();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                service.Create(dto);
                return RedirectToAction("Index", "Book");
            }

            ViewBag.Categories = new CategoryService().GetAll();
            return View(dto);
        }
    }
}