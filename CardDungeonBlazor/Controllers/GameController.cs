﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAnimate;
using CardDungeonBlazor.Areas.Cards;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using CardGame;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Services.ServiceModels.GameModels;
using Services.Services;

namespace CardDungeonBlazor.Controllers
    {
    public class GameController : ComponentBase
        {
        [Inject]
        protected GameService Service { get; set; }

        public GameViewModel Model { get; set; }

        public CardViewModel PlayedCard { get; set; }

        public List<CardViewModel> DescardedCards { get; set; }

        public GetViewModelsFromServiceModels Get;

        public Animate hand;

        public bool cardIsPlayed = false;

        public bool IsPlayedCardHiden = true;

        public bool isDrawAnimationManual = false;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = new GameViewModel();
            this.Model.PlayerModel1.Name = "player1";
            this.Model.PlayerModel2.Name = "player2";
            GameServiceModel gameServiceModel = this.Get.GetGameServiceModel(this.Model);
            this.Service.GameManager = new GameManager(GameService.GetPlayer(gameServiceModel, this.Model.PlayerModel1.Name), GameService.GetPlayer(gameServiceModel, this.Model.PlayerModel2.Name));
            this.Model.PlayerModel1.Deck = this.Get.GetDecksViewModel(this.Service.GetDeck(this.Model.PlayerModel1.Name));
            this.Model.PlayerModel2.Deck = this.Get.GetDecksViewModel(this.Service.GetDeck(this.Model.PlayerModel2.Name));
            this.Model.PlayerModel1.CardsInHeand = this.Get.GetCardViewModels(this.Service.GetCardsInHand());

            }


        public async Task PlayCard ( string cardId, string playerName )
            {
            PlayerViewModel player = new();
            CardViewModel card = new();
            if (this.Model.PlayerModel1.Name == playerName)
                {
                player = Model.PlayerModel1;
                }
            else
                {
                player = Model.PlayerModel2;
                }
            card = player.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
            if (card.Cost > player.Energy)
                {
                return;
                }
            if (player == Model.PlayerModel1)
                {
                this.Model.PlayedCard = this.Model.PlayerModel1.CardsInHeand.FirstOrDefault(c => c.Id == cardId);

                }
            else
                {
                this.Model.PlayedCard = this.Model.PlayerModel2.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
                }
            PlayedCard = this.Model.PlayedCard;
            this.Model = this.Get.GetGameViewModel(await this.Service.PlayCard(cardId, playerName, this.Get.GetGameServiceModel(this.Model)));
            this.Model.PlayedCard = PlayedCard;

            await Task.Delay(20);
            if (this.Model.PlayerModel1.Name == playerName)
                {
                this.Model.PlayedCard.Offcet = 0;
                this.Model.PlayerModel1.DiscardPile.Add(this.Model.PlayedCard);
                }
            else if (this.Model.PlayerModel2.Name == playerName)
                {
                this.Model.PlayedCard.Offcet = 0;
                this.Model.PlayerModel2.DiscardPile.Add(this.Model.PlayedCard);
                }
            Task
                .Delay(100);
            this.Model.PlayedCard = null;

            }

        protected override void OnAfterRender ( bool firstRender )
            {


            foreach (CardViewModel deck in this.Model.PlayerModel2.Deck.Cards)
                {
                deck.Offcet = 0;
                }
            foreach (CardViewModel deck in this.Model.PlayerModel1
                  .Deck.Cards)
                {
                deck.Offcet = 0;
                }
            }

        public async Task EndTurn ()
            {
            await this.Service.EndTurn();
            if (this.Service.GameManager.player.Name == this.Model.PlayerModel2.Name)
                {
                this.isDrawAnimationManual = true;
                this.hand.Run();
                this.Model.PlayerModel2.CardsInHeand = this.Get.GetCardViewModels(this.Service.GetCardsInHand());
                this.Model.PlayerModel1.DiscardPile = new();
                }
            else
                {
                this.Model.PlayerModel1.CardsInHeand = this.Get.GetCardViewModels(this.Service.GetCardsInHand());
                this.Model.PlayerModel2.DiscardPile = new();
                }
            }
        }
    }
