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
            var categories = new CategoryService().Get();
            ViewBag.Categories = categories;

            return View();
        }
        public IActionResult Index()
        {
            var books = service.Get();
            return View(books);
        }

        public IActionResult Edit(int id)
        {
            var book = service.Get(id);

            if (book == null)
                return NotFound();

            var dto = new BookUpdateDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                Description = book.Description,
                Price = book.Price,
                Stock = book.Stock,
                CoverImageUrl = book.CoverImageUrl,
                Publisher = book.Publisher,
                PublishedYear = book.PublishedYear,
                Language = book.Language
            };

            return View(dto);
        }
        [HttpPost]
        public IActionResult Create(BookCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                service.Create(dto);
                return RedirectToAction("Index");
            }

            var categories = new CategoryService().Get();
            ViewBag.Categories = categories;

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(BookUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                service.Update(dto);
                return RedirectToAction("Index");
            }

            return View("Edit", dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}