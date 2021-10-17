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
    public class AddCardsToDeckController : ComponentBase
        {

        [Inject]
        protected ICardsService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<CardViewModel> Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            List<CardServiceModel> cardServiceModels = this.Service.Show(this.HttpContext.HttpContext.User.Identity.Name);
            foreach (CardServiceModel cardServiceModel in cardServiceModels)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                cardViewModel.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
                this.Model.Add(cardViewModel);
                }
            base.OnInitialized();
            }
        public void Add ( string cardId )
            {
            this.Service.AddCardToDeck(cardId, this.Id);
            this.Model.FirstOrDefault(x => x.Id == cardId).TimesAddedInADeck++;
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/decks/all");
            }

        }
    }
