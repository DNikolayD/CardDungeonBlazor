using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.Models;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.ForumModels;
using ServiceLibrary.Models.GameModels;
using ServiceLibrary.Models.UserModels;

namespace CardDungeonBlazor.MannualMapping
    {
    public static class MappingFromViewToService
        {
        public static CardServiceModel CardMapping ( CardViewModel cardViewModel )
            {
            CardServiceModel cardServiceModel = new();
            cardServiceModel.Id = cardViewModel.Id;
            cardServiceModel.Name = cardViewModel.Name;
            cardServiceModel.Description = cardViewModel.Description;
            cardServiceModel.Value = cardViewModel.Value;
            cardServiceModel.Cost = cardViewModel.Cost;
            cardServiceModel.Duration = cardViewModel.Duration;
            cardServiceModel.CreatedOn = cardViewModel.CreatedOn;
            cardServiceModel.IsEdited = cardViewModel.IsEdited;
            cardServiceModel.EditedOn = cardViewModel.EditedOn;
            cardServiceModel.CardType = CardTypeMapping(cardViewModel.CardType);
            cardServiceModel.IsDeleted = cardViewModel.IsDeleted;
            return cardServiceModel;
            }
        public static CardTypeServiceModel CardTypeMapping ( CardTypeViewModel cardTypeViewModel )
            {
            CardTypeServiceModel cardTypeServiceModel = new();
            cardTypeServiceModel.Id = cardTypeViewModel.Id;
            cardTypeServiceModel.Name = cardTypeViewModel.Name;
            cardTypeServiceModel.CreatedOn = cardTypeViewModel.CreatedOn;
            cardTypeServiceModel.IsEdited = cardTypeViewModel.IsEdited;
            cardTypeServiceModel.EditedOn = cardTypeViewModel.EditedOn;
            cardTypeServiceModel.IsDeleted = cardTypeViewModel.IsDeleted;
            return cardTypeServiceModel;
            }
        public static ImageServiceModel ImageMapping ( ImageViewModel imageViewModel )
            {
            ImageServiceModel imageServiceModel = new();
            imageServiceModel.Id = imageViewModel.Id;
            imageServiceModel.Name = imageViewModel.Name;
            imageServiceModel.Img = imageViewModel.Img;
            imageServiceModel.CreatedOn = imageViewModel.CreatedOn;
            imageServiceModel.IsEdited = imageViewModel.IsEdited;
            imageServiceModel.EditedOn = imageViewModel.EditedOn;
            imageServiceModel.IsDeleted = imageViewModel.IsDeleted;
            return imageServiceModel;
            }
        public static DeckServiceModel DeckMapping ( DeckViewModel deckViewModel )
            {
            DeckServiceModel deckServiceModel = new();
            deckServiceModel.Id = deckViewModel.Id;
            deckServiceModel.Name = deckViewModel.Name;
            deckServiceModel.Description = deckViewModel.Description;
            deckServiceModel.DeckType = deckViewModel.DeckType;
            deckServiceModel.CreatedOn = deckViewModel.CreatedOn;
            deckServiceModel.IsEdited = deckViewModel.IsEdited;
            deckServiceModel.EditedOn = deckViewModel.EditedOn;
            deckServiceModel.IsDeleted = deckViewModel.IsDeleted;
            return deckServiceModel;
            }
        public static CategoryServiceModel CategoryMapping ( CategoryViewModel categoryViewModel )
            {
            CategoryServiceModel categoryServiceModel = new();
            categoryServiceModel.Id = categoryViewModel.Id;
            categoryServiceModel.Name = categoryViewModel.Name;
            categoryServiceModel.Description = categoryViewModel.Description;
            categoryServiceModel.CreatedOn = categoryViewModel.CreatedOn;
            categoryServiceModel.IsEdited = categoryViewModel.IsEdited;
            categoryServiceModel.EditedOn = categoryViewModel.EditedOn;
            categoryServiceModel.IsDeleted = categoryViewModel.IsDeleted;
            return categoryServiceModel;
            }
        public static PostServiceModel PostMapping ( PostViewModel postViewModel )
            {
            PostServiceModel postServiceModel = new();
            postServiceModel.Id = postViewModel.Id;
            postServiceModel.Title = postViewModel.Title;
            postServiceModel.TextContent = postViewModel.TextContent;
            postServiceModel.Likes = postViewModel.Likes;
            postServiceModel.Category = CategoryMapping(postViewModel.Category);
            postServiceModel.CreatedOn = postViewModel.CreatedOn;
            postServiceModel.IsEdited = postViewModel.IsEdited;
            postServiceModel.EditedOn = postViewModel.EditedOn;
            postServiceModel.IsDeleted = postViewModel.IsDeleted;
            return postServiceModel;
            }
        public static CommentServiceModel CommentMapping ( CommentViewModel commentViewModel )
            {
            CommentServiceModel commentServiceModel = new();
            commentServiceModel.Id = commentViewModel.Id;
            commentServiceModel.TextContent = commentViewModel.TextContent;
            commentServiceModel.Likes = commentViewModel.Likes;
            commentServiceModel.CreatedOn = commentViewModel.CreatedOn;
            commentServiceModel.IsEdited = commentViewModel.IsEdited;
            commentServiceModel.EditedOn = commentViewModel.EditedOn;
            commentServiceModel.Post = PostMapping(commentViewModel.Post);
            commentServiceModel.IsDeleted = commentViewModel.IsDeleted;
            return commentServiceModel;
            }
        public static UserServiceModel UserMapping ( UserViewModel userViewModel )
            {
            UserServiceModel userServiceModel = new();
            userServiceModel.Id = userViewModel.Id;
            userServiceModel.Name = userViewModel.Name;
            userServiceModel.Wins = userViewModel.Wins;
            userServiceModel.Loses = userViewModel.Loses;
            userServiceModel.CreatedOn = userViewModel.CreatedOn;
            userServiceModel.IsEdited = userViewModel.IsEdited;
            userServiceModel.EditedOn = userViewModel.EditedOn;
            userServiceModel.IsDeleted = userViewModel.IsDeleted;
            return userServiceModel;
            }
        public static RoleServiceModel RoleMapping ( RoleViewModel roleViewModel )
            {
            RoleServiceModel roleServiceModel = new();
            roleServiceModel.Id = roleViewModel.Id;
            roleServiceModel.Name = roleViewModel.Name;
            roleServiceModel.CreatedOn = roleViewModel.CreatedOn;
            roleServiceModel.IsEdited = roleViewModel.IsEdited;
            roleServiceModel.EditedOn = roleViewModel.EditedOn;
            roleServiceModel.IsDeleted = roleViewModel.IsDeleted;
            return roleServiceModel;
            }
        public static GameServiceModel GameMapping ( GameViewModel gameViewModel )
            {
            GameServiceModel gameServiceModel = new();
            gameServiceModel.ActivePlayerName = gameViewModel.ActivePlayerName;
            gameServiceModel.Player1 = PlayerMapping(gameViewModel.Player1);
            gameServiceModel.Player2 = PlayerMapping(gameViewModel.Player2);
            return gameServiceModel;
            }
        public static PlayerServiceModel PlayerMapping ( PlayerViewModel playerViewModel )
            {
            PlayerServiceModel playerServiceModel = new(0, 0, 0);
            List<CardServiceModel> cardsInHand = new();
            List<CardServiceModel> discardPile = new();
            foreach (CardViewModel card in playerViewModel.Hand)
                {
                CardServiceModel cardServiceModel = CardMapping(card);
                cardsInHand.Add(cardServiceModel);
                }
            foreach (CardViewModel card in playerViewModel.DiscardPile)
                {
                CardServiceModel cardServiceModel = CardMapping(card);
                discardPile.Add(cardServiceModel);
                }
            playerServiceModel.Name = playerViewModel.Name;
            playerServiceModel.Energy = playerViewModel.Energy;
            playerServiceModel.Armor = playerViewModel.Armor;
            playerServiceModel.TurnsPoisoned = playerViewModel.TurnsPoisoned;
            playerServiceModel.Hand = cardsInHand;
            playerServiceModel.DiscardPile = discardPile;
            playerServiceModel.Draw = playerViewModel.Draw;
            playerServiceModel.Deck = DeckMapping(playerViewModel.Deck);
            return playerServiceModel;
            }
        }
    }
