using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class PlayerViewModel
        {
        public PlayerViewModel ()
            {
            this.Energy = 3;
            this.Health = 100;
            this.Deck = new DeckViewModel();
            this.CardsInHeand = new List<CardServiceModel>();
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
