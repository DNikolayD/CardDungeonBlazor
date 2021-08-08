using System.Collections.Generic;

namespace CardGame.Models
    {
    public class PlayerModel
        {
        public PlayerModel()
            {
            this.Energy = 3;
            this.Health = 100;
            this.Deck = new DeckModel();
            this.CardsInHeand = new List<CardModel>();
            }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Deffence { get; set; }

        public bool IsPoisoned { get; set; }

        public DeckModel Deck { get; set; }

        public List<CardModel> CardsInHeand { get; set; }
        }
    }
