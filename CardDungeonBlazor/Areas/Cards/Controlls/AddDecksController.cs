using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class AddDecksController : ComponentBase
        {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddDeckFormModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Model = new();
            }

        public void Submit ()
            {
            this.Service.Add(this.Get.GetAddDecksServiceModel(this.Model));
            string deckId = this.Service.GetId(this.Model.Name);
            this.Navigation.NavigateTo($"/deck/addCards/{deckId}");
            }
        }
    }
