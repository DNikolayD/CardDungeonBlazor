using System.Collections.Generic;
using Services.ServiceModels.UserModels;

namespace Services.ServiceModels.CardsModels
    {
    public class AddCardsServiceModel
        {
        public AddCardsServiceModel ()
            {
            this.CardTypes = new List<CardTypeServiceModel>();
            }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CardTypeId { get; set; }

        public string UserName { get; set; }

        public virtual List<CardTypeServiceModel> CardTypes { get; set; }

        public int Value { get; set; }

        public int Cost { get; set; }
        }
    }
