using System.Collections.Generic;
using Services.ServiceModels.CardsModels;

namespace Services.ServiceModels.GameModels
    {
    public class PlayerServiceModel
        {
        public PlayerServiceModel ()
            {
            this.Energy = 3;
            this.Health = 100;
            this.Deck = new DecksServiceModel();
            this.CardsInHeand = new List<CardServiceModel>();
            }

        public string Name { get; set; }

        public int Energy { get; set; }

        public int Health { get; set; }

        public int Deffence { get; set; }

        public bool IsPoisoned { get; set; }

        public DecksServiceModel Deck { get; set; }

        public List<CardServiceModel> CardsInHeand { get; set; }
        }
    }
