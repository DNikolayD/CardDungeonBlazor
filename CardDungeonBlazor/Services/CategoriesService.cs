﻿using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Services
{
    public class CategoriesService
    {
        private readonly ApplicationDbContext data;

        public CategoriesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Add(AddCategoryFormModel model)
        {
            Category dbCategory = new()
            {
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Name = model.Name,
            };
            this.data.Categories.Add(dbCategory);
            this.data.SaveChanges();
        }

        public AllCategoriesViewModel GetAllCategories()
        {
            AllCategoriesViewModel model = new();
            IQueryable<Category> categories = this.data.Categories.Where(c => !c.IsDeleted);
            foreach (var category in categories)
            {
                CategoryServiceModel serviceModel = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    PostsCount = category.Posts.Count,
                };
                model.Categories.Add(serviceModel);
            }
            return model;
        }

        public void Delete(string id)
        {
            Category dbCategory = this.data.Categories.FirstOrDefault(c => c.Id == id);
            dbCategory.IsDeleted = true;
            dbCategory.DeletedOn = DateTime.UtcNow;
            this.data.Categories.Update(dbCategory);
            this.data.SaveChanges();
        }

        public AddCategoryFormModel GetCategoryById(string id)
        {
            Category category = this.data.Categories.FirstOrDefault(c => c.Id == id);
            AddCategoryFormModel model = new()
            {
                Description = category.Description,
                Name = category.Name,
            };
            return model;
        }

        public void Edit(string id, AddCategoryFormModel model)
        {
            Category category = this.data.Categories.FirstOrDefault(c => c.Id == id);
            category.Name = model.Name;
            category.Description = model.Description;
            this.data.Categories.Update(category);
            this.data.SaveChanges();
        }
    }
}
