using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;

namespace CardDungeonBlazor.Models
    {
    public class PlayerViewModel
        {
        public PlayerViewModel ( int bonusHealth, int bonusEnergy, int bonusDraw )
            {
            this.Health = 100 + bonusHealth;
            this.Energy = 3 + bonusEnergy;
            this.Draw = 5 + bonusDraw;
            this.Hand = new();
            this.Deck = new();
            this.DiscardPile = new();
            }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public int TurnsPoisoned { get; set; }

        public DeckViewModel Deck { get; set; }

        public List<CardViewModel> Hand { get; set; }

        public List<CardViewModel> DiscardPile { get; set; }

        public int Draw { get; set; }
        }
    }
