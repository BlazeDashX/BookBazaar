using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class BookRepository
    {
        private readonly BookShopDbContext db;

        public BookRepository(BookShopDbContext db)
        {
            this.db = db;
        }



        public List<Book> Get()
        {
            return db.Books
                     .Include(b => b.Category)
                     .Where(b => b.IsActive)
                     .ToList();
        }

        public Book? Get(int id)
        {
            return db.Books
                     .Include(b => b.Category)
                     .FirstOrDefault(b => b.Id == id);
        }

        public bool Create(Book b)
        {
            db.Books.Add(b);
            return db.SaveChanges() > 0;
        }

        public bool Update(Book b)
        {
            var exobj = db.Books.FirstOrDefault(x => x.Id == b.Id);

            if (exobj == null)
                return false;

            exobj.Title = b.Title;
            exobj.Author = b.Author;
            exobj.Price = b.Price;
            exobj.Stock = b.Stock;
            exobj.Description = b.Description;
            exobj.CoverImageUrl = b.CoverImageUrl;
            exobj.Publisher = b.Publisher;
            exobj.PublishedYear = b.PublishedYear;
            exobj.Language = b.Language;
            exobj.CategoryId = b.CategoryId;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var book = db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return false;

            book.IsActive = false;

            return db.SaveChanges() > 0;
        }
    }
}