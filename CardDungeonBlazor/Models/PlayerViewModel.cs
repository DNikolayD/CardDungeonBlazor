using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;

namespace CardDungeonBlazor.Models
    {
    public class PlayerViewModel
        {
        public PlayerViewModel ()
            {
            this.Energy = 3;
            this.Health = 100;
            this.Deck = new();
            this.CardsInHeand = new();
            this.DiscardPile = new();
            }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public int TurnsPoisoned { get; set; }

        public DeckViewModel Deck { get; set; }

        public List<CardViewModel> CardsInHeand { get; set; }

        public List<CardViewModel> DiscardPile { get; set; }
        }
    }
