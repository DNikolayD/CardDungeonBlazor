using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
{
    public class AddCardsToDeckController : ComponentBase
    {
        [Inject]
        protected AddCardsToDeckService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected CardAddedToDeck CardsAdded { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override void OnInitialized()
        {
            CardsAdded.Cards = Service.GetAllCards().Cards;

        }
        public void Add(string CardId)
        {
            CardsAdded.Cards.Find(x => x.Id == CardId).TimesAdded++;
            Service.AddCardsToDeckWithId(CardId, Id);
        }
        public void Redirect()
        {
            Navigation.NavigateTo("/decks/all");
        }
    }
}
