using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class ChooseDeckController : ComponentBase
        {
        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public GetViewModelsFromServiceModels Get;

        public AllDeckViewModel Model;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAllDeckViewModel(this.Service.GetAll());
            }

        public void Redirect ( string id )
            {
            this.Navigation.NavigateTo($"/game/main/{id}");
            }
        }
    }
