using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class AllDecksController : ComponentBase
        {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AllDeckViewModel Model;

        protected override void OnInitialized ()
            {
            this.Model = new();
            this.Model.Decks = this.Service.GetAll().Decks;

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
