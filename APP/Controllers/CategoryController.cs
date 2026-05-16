using BLL.DTOs;
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
            var categories = service.Get();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var data = service.Get(id);

            if (data == null)
                return NotFound();

            var dto = new CategoryUpdateDTO
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                CreatedAt = data.CreatedAt
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDTO dto)
        {
            service.Create(dto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Update(CategoryUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", dto);
            }

            var result = service.Update(dto);

            if (!result)
            {
                return View("Edit", dto);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
