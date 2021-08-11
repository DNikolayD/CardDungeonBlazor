using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class AllDeckViewModel
        {
        public AllDeckViewModel ()
            {
            this.Decks = new List<DeckViewModel>();
            }

        public List<DeckViewModel> Decks { get; set; }
        }
    }
