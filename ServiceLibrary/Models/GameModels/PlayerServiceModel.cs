using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CardModels;

namespace ServiceLibrary.Models.GameModels
    {
    public class PlayerServiceModel
        {

        public PlayerServiceModel ()
            {
            this.Health = 100;
            this.Energy = 3;
            this.Hand = new();
            this.Deck = new();
            this.DiscardPile = new();
            }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Energy { get; set; }

        public int Armor { get; set; }

        public List<CardServiceModel> Hand { get; set; }

        public DeckServiceModel Deck { get; set; }

        public List<CardServiceModel> DiscardPile { get; set; }

        public int TurnsPoisoned { get; set; }
        }
    }
