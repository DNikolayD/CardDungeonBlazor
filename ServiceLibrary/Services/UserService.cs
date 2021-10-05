using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using ServiceLibrary.Interfaces;
using ServiceLibrary.MannualMapping;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.ForumModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Services
    {
    public class UserService : IUserService
        {

        private readonly ApplicationDbContext dbContext;

        public UserService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public bool Edit ( UserServiceModel userServiceModel )
            {
            ApplicationUser user = this.dbContext.GetUsers().FirstOrDefault(x => x.UserName == userServiceModel.Name);
            user.ProfilePhotoId = userServiceModel.ProfilePhoto.Id;
            user.NickName = userServiceModel.Name;
            this.dbContext.Users.Update(user);
            this.dbContext.SaveChanges();
            return this.dbContext.GetUsers().Contains(user);
            }

        public UserServiceModel Show ( string userName )
            {
            ApplicationUser user = this.dbContext.GetUsers().FirstOrDefault(x => x.UserName == userName);
            UserServiceModel userServiceModel = MappingFromDbToService.UserMapping(user);
            List<CardServiceModel> createdCards = new();
            List<DeckServiceModel> createdDecks = new();
            List<PostServiceModel> posts = new();
            List<CommentServiceModel> comments = new();
            List<PostServiceModel> likedPosts = new();
            List<CommentServiceModel> likedComments = new();
            userServiceModel.ProfilePhoto = MappingFromDbToService.ImageMapping(this.dbContext.Images.FirstOrDefault(x => x.Id == user.ProfilePhotoId));
            foreach (Card card in user.CreatedCards)
                {
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                createdCards.Add(cardServiceModel);
                }
            foreach (Deck deck in user.CreatedDecks)
                {
                DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
                createdDecks.Add(deckServiceModel);
                }
            foreach (Post post in user.Posts)
                {
                PostServiceModel postServiceModel = MappingFromDbToService.PostMapping(post);
                posts.Add(postServiceModel);
                }
            foreach (Comment comment in user.Comments)
                {
                CommentServiceModel commentServiceModel = MappingFromDbToService.CommentMapping(comment);
                comments.Add(commentServiceModel);
                }
            foreach (Post post in user.LikedPosts)
                {
                PostServiceModel postServiceModel = MappingFromDbToService.PostMapping(post);
                likedPosts.Add(postServiceModel);
                }
            foreach (Comment comment in user.LikedComments)
                {
                CommentServiceModel commentServiceModel = MappingFromDbToService.CommentMapping(comment);
                likedComments.Add(commentServiceModel);
                }
            userServiceModel.Comments = comments;
            userServiceModel.Posts = posts;
            userServiceModel.CreatedCards = createdCards;
            userServiceModel.CreatedDecks = createdDecks;
            userServiceModel.LikedComments = likedComments;
            userServiceModel.LikedPosts = likedPosts;
            return userServiceModel;
            }
        }
    }
