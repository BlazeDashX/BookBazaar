using DAL.EF;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository repo;

        public CategoryService()
        {
            var db = new BookShopDbContext();
            repo = new CategoryRepository(db);
        }

        public List<Category> GetAll()
        {
            return repo.GetAll();
        }

        public bool Create(Category c)
        {
            return repo.Create(c);
        }
    }
}
