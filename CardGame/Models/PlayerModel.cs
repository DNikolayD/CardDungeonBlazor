using System.Collections.Generic;

namespace CardGame.Models
    {
    public class PlayerModel
        {
        public PlayerModel ()
            {
            this.Energy = 3;
            this.Health = 100;
            this.Deck = new();
            this.CardsInHeand = new();
            this.DescardPile = new();
            }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Deffence { get; set; }

        public bool IsPoisoned { get; set; }

        public DeckModel Deck { get; set; }

        public List<CardModel> CardsInHeand { get; set; }

        public List<CardModel> DescardPile { get; set; }

        public int TurnsPoisoned { get; set; }
        }
    }
