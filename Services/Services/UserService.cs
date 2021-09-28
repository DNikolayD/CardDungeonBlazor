using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.ServiceModels.CardsModels;
using Services.ServiceModels.ForumsModels;
using Services.ServiceModels.UserModels;

namespace Services.Services
    {
    public class UserService : IUserService
        {

        private readonly ApplicationDbContext applicationDbContext;

        public UserService ( ApplicationDbContext applicationDbContext )
            {
            this.applicationDbContext = applicationDbContext;
            }

        public void Edit ( Show user )
            {
            throw new NotImplementedException();
            }

        public Show GetShow ( string userName )
            {
            string identityUserId = this.applicationDbContext.GetUsers().FirstOrDefault(x => x.UserName == userName).Id;
            ApplicationUser User = this.applicationDbContext.GetUsers().FirstOrDefault(x => x.Id == identityUserId);
            Show user = new();
            List<CommentServiceModel> comments = new();
            IQueryable<Comment> dbComments = this.applicationDbContext.Comments.Where(x => x.PostedByUserId == identityUserId);
            List<PostServiceModel> posts = new();
            IQueryable<Post> dbPosts = this.applicationDbContext.Posts.Where(x => x.PostedByUserId == identityUserId);
            List<CommentServiceModel> likedComments = new();
            List<PostServiceModel> likedPosts = new();
            List<CardServiceModel> cards = new();
            IQueryable<Card> dbCards = this.applicationDbContext.Cards.Where(x => x.CreatedByUserId == identityUserId);
            List<DeckServiceModel> decks = new();
            IQueryable<Deck> dbDecks = this.applicationDbContext.Decks.Where(x => x.CreatedByUserId == identityUserId);
            foreach (Comment dbComment in dbComments)
                {
                CommentServiceModel comment = new();
                comment.CreatedOn = dbComment.CreatedOn.ToString();
                comment.Image = dbComment.Image;
                comment.Likes = dbComment.Likes;
                comment.Text = dbComment.TextContent;
                comment.Username = dbComment.PostedByUser.NickName;
                comments.Add(comment);
                }
            foreach (Card dbCard in dbCards)
                {
                CardServiceModel card = new();
                card.CardType = dbCard.CardType.Name;
                card.Cost = dbCard.Cost;
                card.Id = dbCard.Id;
                card.ImageUrl = dbCard.ImageUrl;
                card.Name = dbCard.Name;
                card.Value = dbCard.Value;
                card.IsHidden = false;
                card.Offcet = 0;
                cards.Add(card);
                }
            foreach (Deck dbDeck in dbDecks)
                {
                string cardId = applicationDbContext.CardDecks.FirstOrDefault(x => x.DeckId == dbDeck.Id).CardId;
                DeckServiceModel deck = new();
                deck.Cards = dbDeck.Cards.Count;
                deck.Id = dbDeck.Id;
                deck.ImageUrl = applicationDbContext.Cards.FirstOrDefault(x => x.Id == cardId).ImageUrl;
                deck.Name = dbDeck.Name;
                deck.Type = dbDeck.DeckType.ToString();
                }
            foreach (Comment dbLikedComment in User.LikedComments)
                {
                CommentServiceModel comment = new();
                comment.CreatedOn = dbLikedComment.CreatedOn.ToString();
                comment.Image = dbLikedComment.Image;
                comment.Likes = dbLikedComment.Likes;
                comment.Text = dbLikedComment.TextContent;
                comment.Username = dbLikedComment.PostedByUser.NickName;
                likedComments.Add(comment);
                }
            foreach (Post dbLikedPost in User.LikedPosts)
                {
                PostServiceModel post = new();
                post.Id = dbLikedPost.Id;
                post.Likes = dbLikedPost.Likes;
                post.Title = dbLikedPost.Title;
                likedPosts.Add(post);
                }
            foreach (Post dbPost in User.Posts)
                {
                PostServiceModel post = new();
                post.Id = dbPost.Id;
                post.Likes = dbPost.Likes;
                post.Title = dbPost.Title;
                posts.Add(post);
                }
            user.Comments = comments;
            user.CreatedCards = cards;
            user.CreatedDecks = decks;
            user.CreatedOn = this.applicationDbContext.GetUsers().FirstOrDefault(x => x.Id == identityUserId).CreatedOn;
            user.Id = identityUserId;
            user.LikedComments = likedComments;
            user.LikedPosts = likedPosts;
            user.Loses = User.Loses;
            user.NickName = User.NickName;
            user.Posts = posts;
            user.ProfilePhoto.Img = User.ProfilePhoto.Img;
            user.Wins = User.Wins;
            return user;
            }
        }
    }
