using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using CardDungeonBlazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.GameModels;

namespace CardDungeonBlazor.Controllers
    {
    public class GameController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected IGameService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        public GameViewModel Model { get; set; }

        public CardViewModel PlayedCard { get; set; }

        int delay = 1000;

        string playerName;

        protected override void OnInitialized ()
            {
            this.playerName = this.HttpContextAccessor.HttpContext.User.Identity.Name;
            this.Service.LoadGame(this.playerName, this.Id);
            this.Model = MappingFromServiceToView.GameMapping(this.Service.Game);
            List<CardViewModel> playerCards = new();
            List<CardViewModel> botCards = new();
            foreach (CardServiceModel cardServiceModel in Service.Game.Player1.Deck.Cards)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModel.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
                cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                playerCards.Add(cardViewModel);
                }
            foreach (CardServiceModel cardServiceModel in Service.Game.Player2.Deck.Cards)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModel.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
                cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                botCards.Add(cardViewModel);
                }
            this.Model.Player1.Deck.Cards = playerCards;
            this.Model.Player2.Deck.Cards = botCards;
            base.OnInitialized();
            }

        public async Task PlayCard ( string cardId )
            {
            if (this.playerName == this.Model.ActivePlayerName)
                {
                CardViewModel cardViewModel = Model.Player1.Hand.FirstOrDefault(x => x.Id == cardId);
                if (cardViewModel.Cost <= this.Model.Player1.Energy)
                    {
                    this.PlayedCard = cardViewModel;
                    }
                }
            else
                {
                CardViewModel cardViewModel = Model.Player2.Hand.FirstOrDefault(x => x.Id == cardId);
                if (cardViewModel.Cost <= this.Model.Player1.Energy)
                    {
                    this.PlayedCard = cardViewModel;
                    }
                }
            this.StateHasChanged();
            this.Service.PlayCard(this.Model.ActivePlayerName, cardId);
            await Task.Delay(delay);
            this.Model = MappingFromServiceToView.GameMapping(this.Service.Game);
            this.PlayedCard = null;
            this.StateHasChanged();
            await Task.Delay(delay);
            }

        public async Task EndTurn ()
            {
            await this.Service.EndTurn();
            this.Model = MappingFromServiceToView.GameMapping(this.Service.Game);
            await Task.Delay(delay);
            if (this.Model.ActivePlayerName == this.Model.Player2.Name)
                {
                await this.BotScript();
                }
            }

        private async Task BotScript ()
            {
            foreach (CardViewModel cardViewModel in this.Model.Player2.Hand)
                {
                if (this.Model.Player2.Energy >= cardViewModel.Cost)
                    {
                    await this.PlayCard(cardViewModel.Id);
                    }
                }
            await this.EndTurn();
            }

        }
    }
