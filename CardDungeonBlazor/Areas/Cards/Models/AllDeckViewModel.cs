using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class AllDeckViewModel
        {
        public AllDeckViewModel ()
            {
            this.Decks = new List<DeckServiceModel>();
            }

        public List<DeckServiceModel> Decks { get; set; }
        }
    }
