﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public static class MappingFromServiceToView
        {
        public static CardViewModel CardMapping ( CardServiceModel cardServiceModel )
            {
            CardViewModel cardViewModel = new();
            cardViewModel.Id = cardServiceModel.Id;
            cardViewModel.Name = cardServiceModel.Name;
            cardViewModel.Description = cardServiceModel.Description;
            cardViewModel.Value = cardServiceModel.Value;
            cardViewModel.Cost = cardServiceModel.Cost;
            cardViewModel.Duration = cardServiceModel.Duration;
            cardViewModel.CreatedOn = cardServiceModel.CreatedOn;
            cardViewModel.IsEdited = cardServiceModel.IsEdited;
            cardViewModel.EditedOn = cardServiceModel.EditedOn;
            return cardViewModel;
            }
        public static CardTypeViewModel CardTypeMapping ( CardTypeServiceModel cardTypeServiceModel )
            {
            CardTypeViewModel cardTypeViewModel = new();
            cardTypeViewModel.Id = cardTypeServiceModel.Id;
            cardTypeViewModel.Name = cardTypeServiceModel.Name;
            cardTypeViewModel.CreatedOn = cardTypeServiceModel.CreatedOn;
            cardTypeViewModel.IsEdited = cardTypeServiceModel.IsEdited;
            cardTypeViewModel.EditedOn = cardTypeServiceModel.EditedOn;
            return cardTypeViewModel;
            }
        public static ImageViewModel ImageMapping ( ImageServiceModel imageServiceModel )
            {
            ImageViewModel imageViewModel = new();
            imageViewModel.Id = imageServiceModel.Id;
            imageViewModel.Name = imageServiceModel.Name;
            imageViewModel.Img = imageServiceModel.Img;
            imageViewModel.CreatedOn = imageServiceModel.CreatedOn;
            imageViewModel.IsEdited = imageServiceModel.IsEdited;
            imageViewModel.EditedOn = imageServiceModel.EditedOn;
            return imageViewModel;
            }
        public static DeckViewModel DeckMapping ( DeckServiceModel deckServiceModel )
            {
            DeckViewModel deckViewModel = new();
            deckViewModel.Id = deckServiceModel.Id;
            deckViewModel.Name = deckServiceModel.Name;
            deckViewModel.Description = deckServiceModel.Description;
            deckViewModel.DeckType = deckServiceModel.DeckType;
            deckViewModel.CreatedOn = deckServiceModel.CreatedOn;
            deckViewModel.IsEdited = deckServiceModel.IsEdited;
            deckViewModel.EditedOn = deckServiceModel.EditedOn;
            return deckViewModel;
            }
        public static CategoryViewModel CategoryMapping ( CategoryServiceModel categoryServiceModel )
            {
            CategoryViewModel categoryViewModel = new();
            categoryViewModel.Id = categoryServiceModel.Id;
            categoryViewModel.Name = categoryServiceModel.Name;
            categoryViewModel.Description = categoryServiceModel.Description;
            categoryViewModel.CreatedOn = categoryServiceModel.CreatedOn;
            categoryViewModel.IsEdited = categoryServiceModel.IsEdited;
            categoryViewModel.EditedOn = categoryServiceModel.EditedOn;
            return categoryViewModel;
            }
        public static PostViewModel PostMapping ( PostServiceModel postServiceModel )
            {
            PostViewModel postViewModel = new();
            postViewModel.Id = postServiceModel.Id;
            postViewModel.Title = postServiceModel.Title;
            postViewModel.TextContent = postServiceModel.TextContent;
            postViewModel.Likes = postServiceModel.Likes;
            postViewModel.Category = CategoryMapping(postServiceModel.Category);
            postViewModel.CreatedOn = postServiceModel.CreatedOn;
            postViewModel.IsEdited = postServiceModel.IsEdited;
            postViewModel.EditedOn = postServiceModel.EditedOn;
            return postViewModel;
            }
        public static CommentViewModel CommentMapping ( CommentServiceModel commentServiceModel )
            {
            CommentViewModel commentViewModel = new();
            commentViewModel.Id = commentServiceModel.Id;
            commentViewModel.TextContent = commentServiceModel.TextContent;
            commentViewModel.Likes = commentServiceModel.Likes;
            commentViewModel.CreatedOn = commentServiceModel.CreatedOn;
            commentViewModel.IsEdited = commentServiceModel.IsEdited;
            commentViewModel.EditedOn = commentServiceModel.EditedOn;
            commentViewModel.Post = PostMapping(commentServiceModel.Post);
            return commentViewModel;
            }
        public static UserViewModel UserMapping ( UserServiceModel userServiceModel )
            {
            UserViewModel userViewModel = new();
            userViewModel.Id = userServiceModel.Id;
            userViewModel.Name = userServiceModel.Name;
            userViewModel.Wins = userServiceModel.Wins;
            userViewModel.Loses = userServiceModel.Loses;
            userViewModel.Role = RoleMapping(userServiceModel.Role);
            userViewModel.CreatedOn = userServiceModel.CreatedOn;
            userViewModel.IsEdited = userServiceModel.IsEdited;
            userViewModel.EditedOn = userServiceModel.EditedOn;
            return userViewModel;
            }
        public static RoleViewModel RoleMapping ( RoleServiceModel roleServiceModel )
            {
            RoleViewModel roleViewModel = new();
            roleViewModel.Id = roleServiceModel.Id;
            roleViewModel.Name = roleServiceModel.Name;
            roleViewModel.CreatedOn = roleServiceModel.CreatedOn;
            roleViewModel.IsEdited = roleServiceModel.IsEdited;
            roleViewModel.EditedOn = roleServiceModel.EditedOn;
            return roleViewModel;
            }
        public static GameViewModel GameMapping ( GameServiceModel gameServiceModel )
            {
            GameViewModel gameViewModel = new();
            gameViewModel.ActivePlayerName = gameServiceModel.ActivePlayerName;
            gameViewModel.Player1 = PlayerMapping(gameServiceModel.Player1);
            gameViewModel.Player2 = PlayerMapping(gameServiceModel.Player2);
            return gameViewModel;
            }
        public static PlayerViewModel PlayerMapping ( PlayerServiceModel playerServiceModel )
            {
            PlayerViewModel playerViewModel = new();
            List<CardViewModel> cardsInHand = new();
            List<CardViewModel> discardPile = new();
            foreach (CardServiceModel card in playerServiceModel.Hand)
                {
                CardViewModel cardViewModel = CardMapping(card);
                cardsInHand.Add(cardViewModel);
                }
            foreach (CardServiceModel card in playerServiceModel.DiscardPile)
                {
                CardViewModel cardViewModel = CardMapping(card);
                discardPile.Add(cardViewModel);
                }
            playerViewModel.Name = playerServiceModel.Name;
            playerViewModel.Energy = playerServiceModel.Energy;
            playerViewModel.Armor = playerServiceModel.Armor;
            playerViewModel.TurnsPoisoned = playerServiceModel.TurnsPoisoned;
            playerViewModel.CardsInHeand = cardsInHand;
            playerViewModel.DiscardPile = discardPile;
            playerViewModel.Deck = DeckMapping(playerServiceModel.Deck);
            return playerViewModel;
            }
        }
    }
