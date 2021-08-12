using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class AddCardsController : ComponentBase
        {
        [Inject]
        protected CardsService Service { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public AddCardFormModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = new();
            this.Model.CardTypes = this.Get.GetCardTypeViewModels(this.Service.GetCardTypeViewModels());
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Add(this.Get.GetAddCardsServiceModel(this.Model));
            this.NavigationManager.NavigateTo("/cards/all");
            }
        }
    }
