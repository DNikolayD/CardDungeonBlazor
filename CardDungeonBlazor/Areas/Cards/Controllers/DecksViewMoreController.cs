using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class DecksViewMoreController : ComponentBase
        {
        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public DeckViewModel Model { get; set; }

        protected override void OnInitialized ()
            {
            DeckServiceModel deckServiceModel = this.Service.ShowFull(this.Id);
            this.Model = MappingFromServiceToView.DeckMapping(deckServiceModel);
            List<CardViewModel> cardViewModels = new();
            foreach (CardServiceModel cardServiceModel in deckServiceModel.Cards)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModels.Add(cardViewModel);
                }
            this.Model.Cards = cardViewModels;
            this.Model.CreatedByUser = MappingFromServiceToView.UserMapping(deckServiceModel.CreatedByUser);
            base.OnInitialized();
            }

        public void RedirectToAllDecks ()
            {
            this.Navigation.NavigateTo("/decks/all");
            }
        public void RedirectToCardsInTheDeck ()
            {
            this.Navigation.NavigateTo($"/decks/cards/{this.Id}");
            }
        }
    }
