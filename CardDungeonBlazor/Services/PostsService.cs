using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.PostModels;

namespace CardDungeonBlazor.Services
    {
    public class PostsService
        {

        private readonly ApplicationDbContext data;

        public PostsService ( ApplicationDbContext data )
            {
            this.data = data;
            }

        public string GetUserId ( string name )
            {
            return this.data.Users.FirstOrDefault(u => u.UserName == name).Id;
            }

        public void AddPost ( AddPostFormModel model )
            {
            Post post = new()
                {
                Title = model.Title,
                CategoryId = model.CategoryId,
                Images = model.Image,
                TextContent = model.TextContent,
                PostedByUserId = model.UserId
                };
            this.data.Posts.Add(post);
            this.data.SaveChanges();
            }
        public AllPostsViewModel GetPosts ( string id )
            {
            AllPostsViewModel model = new();
            IQueryable<Post> posts = this.data.Posts.Where(p => p.CategoryId == id && !p.IsDeleted);
            if (posts.Any())
                {
                foreach (Post post in posts)
                    {
                    PostServiceModel serviceModel = new()
                        {
                        Id = post.Id,
                        Title = post.Title,
                        Likes = post.Likes,
                        };
                    model.Posts.Add(serviceModel);
                    }
                }
            return model;
            }
        public void Delete ( string id )
            {
            Post post = this.data.Posts.FirstOrDefault(p => p.Id == id);
            post.IsDeleted = true;
            post.DeletedOn = DateTime.UtcNow;
            this.data.Posts.Update(post);
            this.data.SaveChanges();
            }
        public AddPostFormModel GetPostsForm ( string id )
            {
            Post post = this.data.Posts.FirstOrDefault(p => p.Id == id);
            AddPostFormModel model = new()
                {
                CategoryId = post.CategoryId,
                Image = post.Images,
                Likes = post.Likes,
                TextContent = post.TextContent,
                Title = post.Title,
                UserId = post.PostedByUserId,
                };
            return model;
            }

        public void Edit(AddPostFormModel model, string id )
            {
            Post post = this.data.Posts.FirstOrDefault(p => p.Id == id);
            post.Images = model.Image;
            post.Title = model.Title;
            post.TextContent = model.TextContent;
            post.Likes = 0;
            this.data.Posts.Update(post);
            this.data.SaveChanges();
            }

        public FullPostViewModel GetFullPost (string id)
            {
            Post post = this.data.Posts.FirstOrDefault(p => p.Id == id);
            List<Comment> comments = post.Comments.ToList();
            List<CommentServiceModel> commentServices = new();
            foreach (var comment in comments)
                {
                commentServices.Add(
                    new CommentServiceModel
                        {
                        CreatedOn = comment.CreatedOn.ToShortDateString(),
                        Image = comment.Image,
                        Likes = comment.Likes,
                        Text = comment.TextContent,
                        Username = comment.PostedByUser.UserName,
                        }
                    );
                }
            FullPostViewModel model = new()
                {
                Comments = commentServices,
                Username = this.data.Users.FirstOrDefault(u => u.Id == post.PostedByUserId).UserName,
                CreatedOn = post.CreatedOn.ToShortDateString(),
                Text = post.TextContent,
                Image = post.Images,
                Likes = post.Likes,
                Title = post.Title,

                };
            return model;
            }
        public void AddComment(string id, CommentServiceModel model )
            {
            Comment comment = new()
                {
                CreatedOn = DateTime.UtcNow,
                Image = model.Image,
                Likes = model.Likes,
                PostId = id,
                PostedByUserId = this.data.Users.FirstOrDefault(u => u.UserName == model.Username).Id,
                TextContent = model.Text,
                };
            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            }
        }
    }
