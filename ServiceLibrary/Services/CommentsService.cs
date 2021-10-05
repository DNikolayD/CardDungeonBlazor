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
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Services
    {
    public class CommentsService : ICommentsService
        {

        private readonly ApplicationDbContext dbContext;

        public CommentsService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public bool Add ( CommentServiceModel commentServiceModel )
            {
            Comment comment = MappingFromServiceToDb.CommentMapping(commentServiceModel);
            List<Image> images = new();
            foreach (ImageServiceModel imageServiceModel in commentServiceModel.Images)
                {
                Image image = MappingFromServiceToDb.ImageMapping(imageServiceModel);
                images.Add(image);
                }
            this.dbContext.Images.AddRange(images);
            this.dbContext.SaveChanges();
            comment.Images = images;
            this.dbContext.Comments.Add(comment);
            this.dbContext.SaveChanges();
            return this.dbContext.Comments.Contains(comment);
            }

        public bool Delete ( string commentId )
            {
            Comment comment = this.dbContext.Comments.Find(commentId);
            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;
            this.dbContext.Comments.Update(comment);
            this.dbContext.SaveChanges();
            comment = this.dbContext.Comments.Find(commentId);
            return comment.IsDeleted;
            }

        public bool Edit ( CommentServiceModel commentServiceModel )
            {
            Comment comment = MappingFromServiceToDb.CommentMapping(commentServiceModel);
            List<Image> images = new();
            foreach (ImageServiceModel imageServiceModel in commentServiceModel.Images)
                {
                Image image = MappingFromServiceToDb.ImageMapping(imageServiceModel);
                images.Add(image);
                }
            this.dbContext.Images.UpdateRange(images);
            this.dbContext.SaveChanges();
            comment.Images = images;
            this.dbContext.Comments.Update(comment);
            this.dbContext.SaveChanges();
            return this.dbContext.Comments.Contains(comment);
            }

        public List<CommentServiceModel> Show ( string postId )
            {
            List<CommentServiceModel> commentServiceModels = new();
            IQueryable<Comment> comments = this.dbContext.Comments.Where(x => x.PostId == postId);
            foreach (Comment comment in comments)
                {
                CommentServiceModel commentServiceModel = MappingFromDbToService.CommentMapping(comment);
                Post post = this.dbContext.Posts.Find(postId);
                commentServiceModel.Post = MappingFromDbToService.PostMapping(post);
                ApplicationUser user = this.dbContext.GetUsers().FirstOrDefault(x => x.Id == comment.PostedByUserId);
                commentServiceModel.PostedByUser = MappingFromDbToService.UserMapping(user);
                List<ImageServiceModel> imageServiceModels = new();
                foreach (Image image in comment.Images)
                    {
                    ImageServiceModel imageServiceModel = MappingFromDbToService.ImageMapping(image);
                    imageServiceModels.Add(imageServiceModel);
                    }
                commentServiceModel.Images = imageServiceModels;
                commentServiceModels.Add(commentServiceModel);
                }
            return commentServiceModels;
            }
        }
    }
