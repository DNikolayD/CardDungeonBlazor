using System.Collections.Generic;

namespace CardDungeonBlazor.Models
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            Energy = 3;
            Health = 100;
            Deck = new DeckViewModel();
            CardsInHeand = new List<CardServiceModel>();
        }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Deffence { get; set; }

        public bool IsPoisoned { get; set; }

        public DeckViewModel Deck { get; set; }

        public List<CardServiceModel> CardsInHeand { get; set; }
    }
}
