using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
{
    public class AddCardsController : ComponentBase
    {
        [Inject]
        protected CardsService Service { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public AddCardFormModel Model { get; set; }

        protected override void OnInitialized()
        {
            Model = new();
            base.OnInitialized();
        }

        public void Submit()
        {
            Service.Add(Model);
            NavigationManager.NavigateTo("/cards/all");
        }
    }
}
