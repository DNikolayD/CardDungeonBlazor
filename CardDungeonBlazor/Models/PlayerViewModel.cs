using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class PlayerViewModel
        {
        public PlayerViewModel ()
            {
            this.Energy = 3;
            this.Health = 100;
            this.Deck = new DecksViewModel();
            this.CardsInHeand = new List<CardViewModel>();
            }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Deffence { get; set; }

        public bool IsPoisoned { get; set; }

        public DecksViewModel Deck { get; set; }

        public List<CardViewModel> CardsInHeand { get; set; }
        }
    }
