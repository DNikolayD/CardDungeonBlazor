using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.ForumModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.MannualMapping
    {
    public static class MappingFromServiceToDb
        {
        public static Card CardMapping ( CardServiceModel cardServiceModel )
            {
            Card card = new();
            if (cardServiceModel.Id!=null)
                {
                card.Id = cardServiceModel.Id;
                }
            card.Name = cardServiceModel.Name;
            card.Value = cardServiceModel.Value;
            card.Cost = cardServiceModel.Cost;
            card.Description = cardServiceModel.Description;
            card.Duration = cardServiceModel.Duration;
            card.CardTypeId = cardServiceModel.CardType.Id;
            card.CreatedOn = cardServiceModel.CreatedOn;
            card.IsEdited = cardServiceModel.IsEdited;
            card.EditedOn = cardServiceModel.EditedOn;
            card.ImageId = cardServiceModel.Image.Id;
            card.CreatedByUserId = cardServiceModel.CreatedByUser.Id;
            return card;
            }
        public static CardType CardTypeMapping ( CardTypeServiceModel cardTypeServiceModel )
            {
            CardType cardType = new();
            cardType.Name = cardTypeServiceModel.Name;
            cardType.CreatedOn = cardTypeServiceModel.CreatedOn;
            cardType.IsEdited = cardTypeServiceModel.IsEdited;
            cardType.EditedOn = cardTypeServiceModel.EditedOn;
            return cardType;
            }
        public static Deck DeckMapping ( DeckServiceModel deckServiceModel )
            {
            Deck deck = new();
            if (deckServiceModel.Id != null)
                {
                deck.Id = deckServiceModel.Id;
                }

            deck.Name = deckServiceModel.Name;
            deck.Description = deckServiceModel.Description;
            deck.DeckType = deckServiceModel.DeckType;
            deck.CreatedOn = deckServiceModel.CreatedOn;
            deck.IsEdited = deckServiceModel.IsEdited;
            deck.EditedOn = deckServiceModel.EditedOn;
            deck.CreatedByUserId = deckServiceModel.CreatedByUser.Id;
            return deck;
            }
        public static Image ImageMapping ( ImageServiceModel imageServiceModel )
            {
            Image image = new();
            if(imageServiceModel.Id != null)
                {
                image.Id = imageServiceModel.Id;
                }

            image.Name = imageServiceModel.Name;
            image.Img = imageServiceModel.Img;
            image.CreatedOn = imageServiceModel.CreatedOn;
            image.IsEdited = imageServiceModel.IsEdited;
            image.EditedOn = imageServiceModel.EditedOn;
            return image;
            }
        public static ApplicationUser UserMapping ( UserServiceModel userServiceModel )
            {
            ApplicationUser applicationUser = new();
            applicationUser.Id = userServiceModel.Id;
            applicationUser.NickName = userServiceModel.Name;
            applicationUser.Wins = userServiceModel.Wins;
            applicationUser.Loses = userServiceModel.Loses;
            applicationUser.ProfilePhotoId = userServiceModel.ProfilePhoto.Id;
            applicationUser.RoleId = userServiceModel.Role.Id;
            applicationUser.Role = RoleMapping(userServiceModel.Role);
            applicationUser.CreatedOn = userServiceModel.CreatedOn;
            applicationUser.IsEdited = userServiceModel.IsEdited;
            applicationUser.EditedOn = userServiceModel.EditedOn;
            return applicationUser;
            }
        public static ApplicationRole RoleMapping ( RoleServiceModel roleServiceModel )
            {
            ApplicationRole applicationRole = new();
            applicationRole.Id = roleServiceModel.Id;
            applicationRole.CreatedOn = roleServiceModel.CreatedOn;
            applicationRole.IsEdited = roleServiceModel.IsEdited;
            applicationRole.EditedOn = roleServiceModel.EditedOn;
            applicationRole.Name = roleServiceModel.Name;
            return applicationRole;
            }
        public static Category CategoryMapping ( CategoryServiceModel categoryServiceModel )
            {
            Category category = new();
            category.Id = categoryServiceModel.Id;
            category.Name = categoryServiceModel.Name;
            category.Description = categoryServiceModel.Description;
            category.CreatedOn = categoryServiceModel.CreatedOn;
            category.IsEdited = categoryServiceModel.IsEdited;
            category.EditedOn = categoryServiceModel.EditedOn;
            return category;
            }
        public static Post PostMapping ( PostServiceModel postServiceModel )
            {
            Post post = new();
            post.Id = postServiceModel.Id;
            post.Title = postServiceModel.Title;
            post.TextContent = postServiceModel.TextContent;
            post.CategoryId = postServiceModel.Category.Id;
            post.PostedByUserId = postServiceModel.PostedByUser.Id;
            post.CreatedOn = postServiceModel.CreatedOn;
            post.IsEdited = postServiceModel.IsEdited;
            post.EditedOn = postServiceModel.EditedOn;
            return post;
            }
        public static Comment CommentMapping ( CommentServiceModel commentServiceModel )
            {
            Comment comment = new();
            comment.Id = commentServiceModel.Id;
            comment.TextContent = commentServiceModel.TextContent;
            comment.Likes = commentServiceModel.Likes;
            comment.PostId = commentServiceModel.Post.Id;
            comment.PostedByUserId = commentServiceModel.PostedByUser.Id;
            comment.CreatedOn = commentServiceModel.CreatedOn;
            comment.IsEdited = commentServiceModel.IsEdited;
            comment.EditedOn = commentServiceModel.EditedOn;
            return comment;
            }
        }
    }
