using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class ChangeCardsInTheDeckController : ComponentBase
        {

        [Inject]
        protected ICardsService CardsService { get; set; }

        [Inject]
        protected IDecksService DecksService { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<CardViewModel> Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            List<CardServiceModel> cardServiceModels = this.CardsService.Show(this.HttpContextAccessor.HttpContext.User.Identity.Name);
            DeckServiceModel deckServiceModel = this.DecksService.ShowFull(this.Id);
            DeckViewModel deckViewModel = MappingFromServiceToView.DeckMapping(deckServiceModel);
            foreach (CardServiceModel cardServiceModel in cardServiceModels)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                cardViewModel.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
                cardViewModel.CreatedByUser = MappingFromServiceToView.UserMapping(cardServiceModel.CreatedByUser);
                cardViewModel.TimesAddedInADeck = deckServiceModel.Cards.Where(x => x.Id == cardServiceModel.Id).Count();
                this.Model.Add(cardViewModel);
                }
            base.OnInitialized();
            }

        public void Add ( string cardId )
            {
            CardViewModel cardViewModel = this.Model.FirstOrDefault(x => x.Id == cardId);
            CardServiceModel cardServiceModel = MappingFromViewToService.CardMapping(cardViewModel);
            this.CardsService.AddCardToDeck(cardId, this.Id);
            cardViewModel.TimesAddedInADeck++;
            }

        public void Remove ( string cardId )
            {
            CardViewModel cardViewModel = this.Model.FirstOrDefault(x => x.Id == cardId);
            CardServiceModel cardServiceModel = MappingFromViewToService.CardMapping(cardViewModel);
            this.CardsService.RemoveCardFromDeck(cardId, this.Id);
            cardViewModel.TimesAddedInADeck--;
            }

        public void Redirect ()
            {
            Navigation.NavigateTo("/decks/all");
            }

        }
    }
