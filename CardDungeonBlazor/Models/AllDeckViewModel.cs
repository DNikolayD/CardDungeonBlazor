using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
