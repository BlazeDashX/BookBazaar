using BLL.DTOs;
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

        public List<CategoryDTO> Get()
        {
            return repo.Get().Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList();
        }
        public CategoryDTO? Get(int id)
        {
            var c = repo.Get(id);

            if (c == null)
            {
                return null;
            }

            return new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            };
        }

        public bool Create(CategoryCreateDTO dto )
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.Now
            };

            return repo.Create(category);
        }
        public bool Update(CategoryUpdateDTO dto)
        {
            var category = repo.Get(dto.Id);

            if (category == null)
            {
                return false;
            }

            category.Name = dto.Name;
            category.Description = dto.Description;

            return repo.Update(category);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
