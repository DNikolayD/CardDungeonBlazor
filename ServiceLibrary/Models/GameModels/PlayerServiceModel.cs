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

        public PlayerServiceModel (int bonusHealth, int bonusEnergy, int bonusDraw)
            {
            this.Health = 100 + bonusHealth;
            this.Energy = 3 + bonusEnergy;
            this.Draw = 5 + bonusDraw;
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

        public int Draw { get; set; }
        }
    }
