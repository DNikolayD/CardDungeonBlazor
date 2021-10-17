using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class AllDecksController : ComponentBase
        {

        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public List<DeckViewModel> Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            List<DeckServiceModel> deckServiceModels = this.Service.Show(this.HttpContext.HttpContext.User.Identity.Name);
            foreach (DeckServiceModel deckServiceModel in deckServiceModels)
                {
                DeckViewModel deckViewModel = MappingFromServiceToView.DeckMapping(deckServiceModel);
                foreach (CardServiceModel cardServiceModel in deckServiceModel.Cards)
                    {
                    CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                    cardViewModel.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
                    cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                    cardViewModel.CreatedByUser = MappingFromServiceToView.UserMapping(cardServiceModel.CreatedByUser);
                    deckViewModel.Cards.Add(cardViewModel);
                    }
                deckServiceModels.Add(deckServiceModel);
                }
            base.OnInitialized();
            }

        public void RedirectToFullView ( string deckId )
            {
            this.Navigation.NavigateTo($"/decks/fullView/{deckId}");
            }

        public void RedirectToEdit ( string deckId )
            {
            this.Navigation.NavigateTo($"/decks/edit/{deckId}");
            }
        public void Delete ( string deckId )
            {
            this.Service.Delete(deckId);
            this.OnInitialized();
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/decks/add");
            }
        }

    }
