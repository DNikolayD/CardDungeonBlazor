using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Areas.Cards.Controlls
    {
    public class AllCardsController : ComponentBase
        {

        [Inject]
        protected CardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AllCardsViewModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAllCardsViewModel(this.Service.GetAllCards());
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/cards/add");
            }

        public void RedirectToFullView ( string id )
            {
            this.Navigation.NavigateTo($"/card/show/{id}");
            }

        public void RedirectToEdit ( string id )
            {
            this.Navigation.NavigateTo($"/card/edit/{id}");
            }

        public void Delete ( string id )
            {
            this.Service.Delete(id);
            this.OnInitialized();
            }
        }
    }
