using System.Collections.Generic;

namespace CardDungeonBlazor.Models
{
    public class AllDeckViewModel
    {
        public AllDeckViewModel()
        {
            Decks = new List<DeckServiceModel>();
        }

        public List<DeckServiceModel> Decks { get; set; }
    }
}
