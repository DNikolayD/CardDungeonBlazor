using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.PostModels;
using ServiceLibrary.Interfaces;
using ServiceLibrary.MannualMapping;
using ServiceLibrary.Models.ForumModels;

namespace ServiceLibrary.Services
    {
    public class CategoriesService : ICategoriesService
        {

        private readonly ApplicationDbContext dbContext;

        public CategoriesService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public bool Add ( CategoryServiceModel categoryServiceModel )
            {
            Category category = MappingFromServiceToDb.CategoryMapping(categoryServiceModel);
            foreach (PostServiceModel postServiceModel in categoryServiceModel.Posts)
                {
                Post post = MappingFromServiceToDb.PostMapping(postServiceModel);
                category.Posts.Add(post);
                }
            this.dbContext.Categories.Add(category);
            this.dbContext.SaveChanges();
            return this.dbContext.Categories.Contains(category);
            }

        public bool Delete ( string categoyId )
            {
            Category category = this.dbContext.Categories.Find(categoyId);
            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;
            this.dbContext.Categories.Update(category);
            this.dbContext.SaveChanges();
            category = this.dbContext.Categories.Find(categoyId);
            return category.IsDeleted;
            }

        public bool Edit ( CategoryServiceModel categoryServiceModel )
            {
            Category category = MappingFromServiceToDb.CategoryMapping(categoryServiceModel);
            foreach (PostServiceModel postServiceModel in categoryServiceModel.Posts)
                {
                Post post = MappingFromServiceToDb.PostMapping(postServiceModel);
                category.Posts.Add(post);
                }
            this.dbContext.Categories.Update(category);
            this.dbContext.SaveChanges();
            return this.dbContext.Categories.Contains(category);
            }

        public List<CategoryServiceModel> Show ()
            {
            List<CategoryServiceModel> categoryServiceModels = new();
            IQueryable<Category> categories = this.dbContext.Categories;
            foreach (Category category in categories)
                {
                CategoryServiceModel categoryServiceModel = MappingFromDbToService.CategoryMapping(category);
                List<PostServiceModel> postServiceModels = new();
                foreach (Post post in category.Posts)
                    {
                    PostServiceModel postServiceModel = MappingFromDbToService.PostMapping(post);
                    postServiceModels.Add(postServiceModel);
                    }
                categoryServiceModel.Posts = postServiceModels;
                categoryServiceModels.Add(categoryServiceModel);
                }
            return categoryServiceModels;
            }
        }
    }
