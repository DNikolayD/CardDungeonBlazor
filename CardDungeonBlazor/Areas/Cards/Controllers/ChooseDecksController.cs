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
    public class ChooseDecksController : ComponentBase
        {
        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public List<DeckViewModel> Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            List<DeckServiceModel> deckServiceModels = this.Service.Show(this.HttpContextAccessor.HttpContext.User.Identity.Name);
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
                this.Model.Add(deckViewModel);
                }
            base.OnInitialized();
            }

        public void StartGame ( string deckId )
            {
            this.Navigation.NavigateTo($"game/main/{deckId}");
            }

        }
    }
