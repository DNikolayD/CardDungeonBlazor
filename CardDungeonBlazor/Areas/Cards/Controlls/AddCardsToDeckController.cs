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
            this.CardsAdded.Cards = this.Service.GetAllCards().Cards;

            }
        public void Add(string CardId)
            {
            this.CardsAdded.Cards.Find(x => x.Id == CardId).TimesAdded++;
            this.Service.AddCardsToDeckWithId(CardId, this.Id);
            }
        public void Redirect()
            {
            this.Navigation.NavigateTo("/decks/all");
            }
        }
    }
