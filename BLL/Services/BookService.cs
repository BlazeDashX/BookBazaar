using DAL.EF;
using DAL.EF.Tables;
using DAL.Repos;
using BLL.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class BookService
    {
        private readonly BookRepository repo;

        public BookService()
        {
            var db = new BookShopDbContext();
            repo = new BookRepository(db);
        }

        public List<BookDTO> Get()
        {
            return repo.Get()
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Price = b.Price,
                    Stock = b.Stock,
                    Description = b.Description,
                    CoverImageUrl = b.CoverImageUrl,
                    Publisher = b.Publisher,
                    PublishedYear = b.PublishedYear,
                    Language = b.Language,
                    CategoryName = b.Category?.Name ?? ""
                })
                .ToList();
        }

        public BookDTO? Get(int id)
        {
            var b = repo.Get(id);

            if (b == null)
            {
                return null;
            }

            return new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price,
                Stock = b.Stock,
                Description = b.Description,
                CoverImageUrl = b.CoverImageUrl,
                Publisher = b.Publisher,
                PublishedYear = b.PublishedYear,
                Language = b.Language,
                CategoryName = b.Category?.Name ?? ""
            };
        }

        public bool Create(BookCreateDTO dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,

                Isbn = dto.Isbn,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,

                CoverImageUrl = dto.CoverImageUrl,
                Publisher = dto.Publisher,
                PublishedYear = dto.PublishedYear,
                Language = dto.Language,

                CategoryId = dto.CategoryId,

                IsActive = true,
                CreatedAt = DateTime.Now
            };

            return repo.Create(book);
        }
    }
}