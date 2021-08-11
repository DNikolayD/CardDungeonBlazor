using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class AllDecksController : ComponentBase
        {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public GetViewModelsFromServiceModels Get;

        public AllDeckViewModel Model;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAllDeckViewModel(this.Service.GetAll());
            }

        public void RedirectToFullView ( string id )
            {
            this.Navigation.NavigateTo($"/deck/show/{id}");
            }

        public void RedirectToEdit ( string id )
            {
            this.Navigation.NavigateTo($"/deck/edit/{id}");
            }

        public void Delete ( string id )
            {
            this.Service.Delete(id);
            this.OnInitialized();
            }

        public void Redirect ()
            {
            this.Navigation.NavigateTo("/decks/add");
            }


        }
    }
