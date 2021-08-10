using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class DeckViewModel
        {
        public DeckViewModel ()
            {
            this.Cards = new List<CardServiceModel>();
            }

        public List<CardServiceModel> Cards { get; set; }
        }
    }
