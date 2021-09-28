using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class CardsViewMoreController : ComponentBase
        {
        [Inject]
        public ICardsService Service { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullCardViewModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetFullCardViewModel(this.Service.GetFullCardView(this.Id));
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/cards/all");
            }
        }
    }
