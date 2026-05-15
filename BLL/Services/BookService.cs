using BLL.DTOs;
using DAL.Repos;

namespace BLL.Services
{
    public class BookService
    {
        private readonly BookRepository repo;

        public BookService()
        {
            repo = new BookRepository();
        }

        public List<BookDTO> GetAllBooks()
        {
            var data = repo.GetAll();

            var books = new List<BookDTO>();

            foreach (var b in data)
            {
                books.Add(new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Price = b.Price,
                    Stock = b.Stock,
                    CoverImageUrl = b.CoverImageUrl,
                    Publisher = b.Publisher,
                    PublishedYear = b.PublishedYear,
                    Language = b.Language,
                    CategoryName = b.Category.Name
                });
            }

            return books;
        }

        public BookDTO? GetBook(int id)
        {
            var b = repo.GetById(id);

            if (b == null) return null;

            return new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Price = b.Price,
                Stock = b.Stock,
                CoverImageUrl = b.CoverImageUrl,
                Publisher = b.Publisher,
                PublishedYear = b.PublishedYear,
                Language = b.Language,
                CategoryName = b.Category.Name
            };
        }
    }
}