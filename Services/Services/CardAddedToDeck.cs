using System.Collections.Generic;
using Services.ServiceModels.CardsModels;

namespace Services.Services
    {
    public class CardAddedToDeck
        {
        public CardAddedToDeck ()
            {
            this.Cards = new List<CardAddedToTheDeckServiceModel>();
            }
        public List<CardAddedToTheDeckServiceModel> Cards { get; set; }
        }
    }
