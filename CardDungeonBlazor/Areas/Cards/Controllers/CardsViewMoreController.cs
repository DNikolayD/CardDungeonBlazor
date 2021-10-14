using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class CardsViewMoreController : ComponentBase
        {
        [Inject]
        protected ICardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public CardViewModel Model { get; set; }

        protected override void OnInitialized ()
            {
            CardServiceModel cardServiceModel = this.Service.ShowFull(this.Id);
            this.Model = MappingFromServiceToView.CardMapping(cardServiceModel);
            this.Model.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
            this.Model.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
            base.OnInitialized();
            }

        public void Redirect ()
            {
            this.Navigation.NavigateTo("/cards/all");
            }
        }
    }
