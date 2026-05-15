using Microsoft.AspNetCore.Mvc;
using BLL.Services;

namespace APP.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService service;

        public BookController()
        {
            service = new BookService();
        }

        public IActionResult Index()
        {
            var books = service.GetAllBooks();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = service.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}