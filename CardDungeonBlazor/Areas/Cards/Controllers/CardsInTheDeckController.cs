using System.Collections.Generic;
using System.Linq;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class CardsInTheDeckController : ComponentBase
        {

        [Inject]
        protected ICardsService CardsService { get; set; }

        [Inject]
        protected IDecksService DecksService { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<CardViewModel> Model { get; set; }

        protected override void OnInitialized ()
            {
            DeckServiceModel deckServiceModel = this.DecksService.ShowFull(this.Id);
            List<CardServiceModel> cardServiceModels = this.CardsService.ShowCardsInTheDeck(this.Id);
            this.Model = new();
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
        public void RedirectToCardsFullView ( string cardId )
            {
            this.Navigation.NavigateTo($"/cards/fullView/{cardId}");
            }
        public void RedirectToDeckFullView ()
            {
            this.Navigation.NavigateTo($"/decks/fullView/{this.Id}");
            }
        public void RedirectToAllDecks ()
            {
            this.Navigation.NavigateTo($"/decks/all");
            }

        }
    }
