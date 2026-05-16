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

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category? Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Create(Category c)
        {
            db.Categories.Add(c);
            return db.SaveChanges() > 0;
        }
        public bool Update(Category c)
        {
            var exobj = db.Categories.FirstOrDefault(x => x.Id == c.Id);

            if (exobj == null)
            {
                return false;
            }

            exobj.Name = c.Name;
            exobj.Description = c.Description;

            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }

            db.Categories.Remove(exobj);
            return db.SaveChanges() > 0;

        }
    }
}
