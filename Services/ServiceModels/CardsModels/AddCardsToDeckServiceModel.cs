using System.Collections.Generic;

namespace Services.ServiceModels.CardsModels
    {
    public class AddCardsToDeckServiceModel
        {
        public AddCardsToDeckServiceModel ()
            {
            this.Cards = new List<CardAddedToTheDeckServiceModel>();
            }
        public List<CardAddedToTheDeckServiceModel> Cards { get; set; }

        }
    }