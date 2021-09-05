using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using static DataConstraints.Deck;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class AddDeckFormModel
        {

        public AddDeckFormModel ()
            {
            this.Cards = new List<AddCardsToDeckModel>();
            }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public DeckType DeckType { get; set; }

        public virtual List<AddCardsToDeckModel> Cards { get; set; }

        }
    }
