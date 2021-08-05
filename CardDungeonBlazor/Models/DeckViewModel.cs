using System.Collections.Generic;

namespace CardDungeonBlazor.Models
{
    public class DeckViewModel
    {
        public DeckViewModel()
        {
            Cards = new List<CardServiceModel>();
        }

        public List<CardServiceModel> Cards { get; set; }
    }
}
