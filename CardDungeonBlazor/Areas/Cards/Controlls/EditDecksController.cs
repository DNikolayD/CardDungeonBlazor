using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class EditDecksController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddDeckFormModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAddDeckFormModel(this.Service.GetDeck(this.Id));
            }

        public void Submit ()
            {
            this.Service.Edit(this.Id, this.Get.GetAddDecksServiceModel(this.Model));
            string deckId = this.Service.GetId(this.Model.Name);
            this.Navigation.NavigateTo($"/deck/addCards/{deckId}");
            }
        }
    }
