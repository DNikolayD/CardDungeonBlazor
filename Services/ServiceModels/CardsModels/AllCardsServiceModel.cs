using System.Collections.Generic;

namespace Services.ServiceModels.CardsModels
    {
    public class AllCardsServiceModel
        {
        public AllCardsServiceModel ()
            {
            this.Cards = new List<CardServiceModel>();
            }
        public List<CardServiceModel> Cards { get; set; }
        }
    }
