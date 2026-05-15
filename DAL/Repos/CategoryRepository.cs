using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class CategoryRepository
    {
        private readonly BookShopDbContext db;

        public CategoryRepository(BookShopDbContext db)
        {
            this.db = db;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool Create(Category c)
        {
            db.Categories.Add(c);
            return db.SaveChanges() > 0;
        }
    }
}
