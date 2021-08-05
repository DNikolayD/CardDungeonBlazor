using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
{
    public class EditCardsController : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected CardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public CardEditFomModel Model;

        protected override void OnInitialized()
        {
            Model = Service.GetEditFomModel(Id);

        }

        public void Submit()
        {
            Service.Edit(Id, Model);
            Navigation.NavigateTo("/cards/all");
        }
    }
}
