using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            Energy = 3;
            Health = 100;
            Deck = new DeckModel();
            CardsInHeand = new List<CardModel>();
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
