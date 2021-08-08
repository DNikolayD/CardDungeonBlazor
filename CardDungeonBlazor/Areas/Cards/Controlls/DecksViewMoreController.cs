using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
    {
    public class DecksViewMoreController : ComponentBase
        {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullDeckViewModel Model;

        protected override void OnInitialized()
            {
            this.Model = this.Service.GetFullDeckView(this.Id);
            }
        public void Redirect()
            {
            this.Navigation.NavigateTo("/decks/all");
            }
        }
    }
