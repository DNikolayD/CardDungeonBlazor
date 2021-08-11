using System;
using System.Linq;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.PostModels;
using Services.ServiceModels.ForumsModels;

namespace Services.Services
    {
    public class CategoriesService
        {
        private readonly ApplicationDbContext data;

        public CategoriesService ( ApplicationDbContext data )
            {
            this.data = data;
            }

        public void Add ( AddCategoryServiceModel model )
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

        public AllCategoriesServiceModel GetAllCategories ()
            {
            AllCategoriesServiceModel model = new();
            IQueryable<Category> categories = this.data.Categories.Where(c => !c.IsDeleted);
            foreach (Category category in categories)
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

        public void Delete ( string id )
            {
            Category dbCategory = this.data.Categories.FirstOrDefault(c => c.Id == id);
            dbCategory.IsDeleted = true;
            dbCategory.DeletedOn = DateTime.UtcNow;
            this.data.Categories.Update(dbCategory);
            this.data.SaveChanges();
            }

        public AddCategoryServiceModel GetCategoryById ( string id )
            {
            Category category = this.data.Categories.FirstOrDefault(c => c.Id == id);
            AddCategoryServiceModel model = new()
                {
                Description = category.Description,
                Name = category.Name,
                };
            return model;
            }

        public void Edit ( string id, AddCategoryServiceModel model )
            {
            Category category = this.data.Categories.FirstOrDefault(c => c.Id == id);
            category.Name = model.Name;
            category.Description = model.Description;
            this.data.Categories.Update(category);
            this.data.SaveChanges();
            }
        }
    }
