using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using Microsoft.AspNetCore.Identity;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.ForumModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.MannualMapping
    {
    public static class MappingFromDbToService
        {

        public static CardServiceModel CardMapping ( Card dbCard )
            {
            CardServiceModel cardServiceModel = new();
            cardServiceModel.Id = dbCard.Id;
            cardServiceModel.Name = dbCard.Name;
            cardServiceModel.Value = dbCard.Value;
            cardServiceModel.Cost = dbCard.Cost;
            cardServiceModel.CreatedOn = dbCard.CreatedOn;
            cardServiceModel.Description = dbCard.Description;
            cardServiceModel.Duration = dbCard.Duration;
            cardServiceModel.IsEdited = dbCard.IsEdited;
            cardServiceModel.EditedOn = dbCard.EditedOn;
            cardServiceModel.IsDeleted = dbCard.IsDeleted;
            return cardServiceModel;
            }
        public static CardTypeServiceModel CardTypeMapping ( CardType dbCardType )
            {
            CardTypeServiceModel cardTypeServiceModel = new();
            cardTypeServiceModel.Id = dbCardType.Id;
            cardTypeServiceModel.CreatedOn = dbCardType.CreatedOn;
            cardTypeServiceModel.EditedOn = dbCardType.EditedOn;
            cardTypeServiceModel.Name = dbCardType.Name;
            cardTypeServiceModel.IsDeleted = dbCardType.IsDeleted;
            return cardTypeServiceModel;
            }
        public static ImageServiceModel ImageMapping ( Image dbImage )
            {
            ImageServiceModel imageServiceModel = new();
            imageServiceModel.Id = dbImage.Id;
            imageServiceModel.Name = dbImage.Name;
            imageServiceModel.Img = dbImage.Img;
            imageServiceModel.IsDeleted = dbImage.IsDeleted;
            return imageServiceModel;
            }
        public static DeckServiceModel DeckMapping ( Deck dbDeck )
            {
            DeckServiceModel deckServiceModel = new();
            deckServiceModel.Id = dbDeck.Id;
            deckServiceModel.Name = dbDeck.Name;
            deckServiceModel.Description = dbDeck.Description;
            deckServiceModel.DeckType = dbDeck.DeckType;
            deckServiceModel.CreatedOn = dbDeck.CreatedOn;
            deckServiceModel.IsEdited = dbDeck.IsEdited;
            deckServiceModel.EditedOn = dbDeck.EditedOn;
            deckServiceModel.IsDeleted = dbDeck.IsDeleted;
            return deckServiceModel;
            }

        public static UserServiceModel UserMapping ( ApplicationUser dbUser )
            {
            UserServiceModel userServiceModel = new();
            userServiceModel.Id = dbUser.Id;
            userServiceModel.IsEdited = dbUser.IsEdited;
            userServiceModel.CreatedOn = dbUser.CreatedOn;
            userServiceModel.EditedOn = dbUser.EditedOn;
            userServiceModel.Name = dbUser.NickName;
            userServiceModel.Wins = dbUser.Wins;
            userServiceModel.Loses = dbUser.Loses;
            userServiceModel.IsDeleted = dbUser.IsDeleted;
            if (dbUser.Role != null)
                {
                userServiceModel.Role = RoleMapping(dbUser.Role);
                }
            return userServiceModel;
            }
        public static RoleServiceModel RoleMapping ( ApplicationRole dbRole )
            {
            RoleServiceModel roleServiceModel = new();
            roleServiceModel.CreatedOn = dbRole.CreatedOn;
            roleServiceModel.EditedOn = dbRole.EditedOn;
            roleServiceModel.IsEdited = dbRole.IsEdited;
            roleServiceModel.Id = dbRole.Id;
            roleServiceModel.Name = dbRole.Name;
            roleServiceModel.IsDeleted = dbRole.IsDeleted;
            return roleServiceModel;
            }
        public static CategoryServiceModel CategoryMapping ( Category dbCategory )
            {
            CategoryServiceModel categoryServiceModel = new();
            categoryServiceModel.Id = dbCategory.Id;
            categoryServiceModel.Name = dbCategory.Name;
            categoryServiceModel.Description = dbCategory.Description;
            categoryServiceModel.CreatedOn = dbCategory.CreatedOn;
            categoryServiceModel.IsEdited = dbCategory.IsEdited;
            categoryServiceModel.EditedOn = dbCategory.EditedOn;
            categoryServiceModel.IsDeleted = dbCategory.IsDeleted;
            return categoryServiceModel;
            }
        public static PostServiceModel PostMapping ( Post dbPost )
            {
            PostServiceModel postServiceModel = new();
            postServiceModel.Id = dbPost.Id;
            postServiceModel.Title = dbPost.Title;
            postServiceModel.TextContent = dbPost.TextContent;
            postServiceModel.Likes = dbPost.Likes;
            postServiceModel.CreatedOn = dbPost.CreatedOn;
            postServiceModel.IsEdited = dbPost.IsEdited;
            postServiceModel.EditedOn = dbPost.EditedOn;
            postServiceModel.IsDeleted = dbPost.IsDeleted;
            return postServiceModel;
            }
        public static CommentServiceModel CommentMapping ( Comment dbComment )
            {
            CommentServiceModel commentServiceModel = new();
            commentServiceModel.Id = dbComment.Id;
            commentServiceModel.TextContent = dbComment.TextContent;
            commentServiceModel.Likes = dbComment.Likes;
            commentServiceModel.CreatedOn = dbComment.CreatedOn;
            commentServiceModel.IsEdited = dbComment.IsEdited;
            commentServiceModel.EditedOn = dbComment.EditedOn;
            commentServiceModel.IsDeleted = dbComment.IsDeleted;
            return commentServiceModel;
            }
        }
    }