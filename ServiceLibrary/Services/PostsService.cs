using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using ServiceLibrary.Interfaces;
using ServiceLibrary.MannualMapping;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.ForumModels;

namespace ServiceLibrary.Services
    {
    public class PostsService : IPostsService
        {

        private readonly ApplicationDbContext dbContext;

        public PostsService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public bool Add ( PostServiceModel postServiceModel )
            {
            Post post = MappingFromServiceToDb.PostMapping(postServiceModel);
            List<Image> images = new();
            foreach (ImageServiceModel imageServiceModel in postServiceModel.Images)
                {
                Image image = MappingFromServiceToDb.ImageMapping(imageServiceModel);
                images.Add(image);
                }
            post.Images = images;
            this.dbContext.Images.AddRange(images);
            this.dbContext.SaveChanges();
            this.dbContext.Posts.Add(post);
            this.dbContext.SaveChanges();
            return this.dbContext.Posts.Contains(post);
            }

        public bool Delete ( string postId )
            {
            Post post = this.dbContext.Posts.Find(postId);
            post.IsDeleted = true;
            post.DeletedOn = DateTime.UtcNow;
            this.dbContext.Posts.Update(post);
            this.dbContext.SaveChanges();
            post = this.dbContext.Posts.Find(postId);
            return post.IsDeleted;
            }

        public bool Edit ( PostServiceModel postServiceModel )
            {
            Post post = MappingFromServiceToDb.PostMapping(postServiceModel);
            List<Image> images = new();
            List<Comment> comments = this.dbContext.Comments.Where(x => x.PostId == post.Id).ToList();
            foreach (ImageServiceModel imageServiceModel in postServiceModel.Images)
                {
                Image image = MappingFromServiceToDb.ImageMapping(imageServiceModel);
                images.Add(image);
                }
            post.Images = images;
            post.Comments = comments;
            this.dbContext.Images.UpdateRange(images);
            this.dbContext.SaveChanges();
            this.dbContext.Posts.Update(post);
            this.dbContext.SaveChanges();
            return this.dbContext.Posts.Contains(post);
            }

        public List<PostServiceModel> Show ( string categoryId )
            {
            List<PostServiceModel> postServiceModels = new();
            IQueryable<Post> posts = this.dbContext.Posts.Where(x => x.CategoryId == categoryId);
            foreach (Post post in posts)
                {
                PostServiceModel postServiceModel = MappingFromDbToService.PostMapping(post);
                Category category = this.dbContext.Categories.Find(categoryId);
                postServiceModel.Category = MappingFromDbToService.CategoryMapping(category);
                ApplicationUser user = this.dbContext.Users.Find(post.PostedByUserId);
                postServiceModel.PostedByUser = MappingFromDbToService.UserMapping(user);
                List<CommentServiceModel> commentServiceModels = new();
                foreach (Comment comment in post.Comments)
                    {
                    CommentServiceModel commentServiceModel = MappingFromDbToService.CommentMapping(comment);
                    commentServiceModels.Add(commentServiceModel);
                    }
                postServiceModel.Comments = commentServiceModels;
                List<ImageServiceModel> imageServiceModels = new();
                foreach (Image image in post.Images)
                    {
                    ImageServiceModel imageServiceModel = MappingFromDbToService.ImageMapping(image);
                    imageServiceModels.Add(imageServiceModel);
                    }
                postServiceModel.Images = imageServiceModels;
                postServiceModels.Add(postServiceModel);
                }
            return postServiceModels;
            }
        }
    }
