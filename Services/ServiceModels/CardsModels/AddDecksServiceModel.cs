using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;

namespace Services.ServiceModels.CardsModels
    {
    public class AddDecksServiceModel
        {

        public AddDecksServiceModel ()
            {
            this.Cards = new List<AddCardsToDeckServiceModel>();
            }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DeckType DeckType { get; set; }

        public virtual List<AddCardsToDeckServiceModel> Cards { get; set; }
        }
    }
