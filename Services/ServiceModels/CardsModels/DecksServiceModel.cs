using System.Collections.Generic;

namespace Services.ServiceModels.CardsModels
    {
    public class DecksServiceModel
        {
        public DecksServiceModel ()
            {
            this.Cards = new List<CardServiceModel>();
            }

        public List<CardServiceModel> Cards { get; set; }
        }
    }
