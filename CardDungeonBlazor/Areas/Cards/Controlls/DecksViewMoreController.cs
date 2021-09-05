using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;
using Services.Services;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class DecksViewMoreController : ComponentBase
        {
        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullDeckViewModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetFullDeckViewModel(this.Service.GetFullDeckView(this.Id));
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/decks/all");
            }
        }
    }
