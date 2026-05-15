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

        public bool Create(Book b)
        {
            db.Books.Add(b);
            return db.SaveChanges() > 0;
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

        public bool Update(Book b)
        {
            var exobj = Get(b.Id);

            if (exobj == null)
            {
                return false;
            }

            db.Entry(exobj).CurrentValues.SetValues(b);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }
            exobj.IsActive = false;
            return db.SaveChanges() > 0;
        }
    }
}