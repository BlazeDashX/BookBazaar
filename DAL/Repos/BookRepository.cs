using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class BookRepository
    {
        private readonly BookShopDbContext db;

        public BookRepository()
        {
            db = new BookShopDbContext();
        }

        public List<Book> GetAll()
        {
            return db.Books
                     .Include(b => b.Category)
                     .Where(b => b.IsActive)
                     .ToList();
        }

        public Book? GetById(int id)
        {
            return db.Books
                     .Include(b => b.Category)
                     .FirstOrDefault(b => b.Id == id);
        }
    }
}