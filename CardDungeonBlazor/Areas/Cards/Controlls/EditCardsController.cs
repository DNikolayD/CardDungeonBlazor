using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class EditCardsController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected ICardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddCardFormModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAddCardFormModel(this.Service.GetEditFomModel(this.Id));

            }

        public void Submit ()
            {
            this.Service.Edit(this.Id, this.Get.GetAddCardsServiceModel(this.Model));
            this.Navigation.NavigateTo("/cards/all");
            }
        }
    }
