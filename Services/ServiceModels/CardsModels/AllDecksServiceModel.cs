using System.Collections.Generic;

namespace Services.ServiceModels.CardsModels
    {
    public class AllDecksServiceModel
        {
        public AllDecksServiceModel ()
            {
            this.Decks = new List<DeckServiceModel>();
            }

        public List<DeckServiceModel> Decks { get; set; }
        }
    }
