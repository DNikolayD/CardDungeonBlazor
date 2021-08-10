using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class EditDecksController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddDeckFormModel Model;

        protected override void OnInitialized ()
            {
            this.Model = this.Service.GetDeck(this.Id);
            }

        public void Submit ()
            {
            this.Service.Edit(this.Id, this.Model);
            string deckId = this.Service.GetId(this.Model.Name);
            this.Navigation.NavigateTo($"/deck/addCards/{deckId}");
            }
        }
    }
