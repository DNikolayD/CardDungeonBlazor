using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
    {
    public class AddDecksController : ComponentBase
        {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddDeckFormModel Model;

        protected override void OnInitialized()
            {
            this.Model = new();
            }

        public void Submit()
            {
            this.Service.Add(this.Model);
            string deckId = this.Service.GetId(this.Model.Name);
            this.Navigation.NavigateTo($"/deck/addCards/{deckId}");
            }
        }
    }
