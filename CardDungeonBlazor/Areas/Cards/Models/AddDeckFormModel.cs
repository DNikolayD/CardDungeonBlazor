using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class AddDeckFormModel
        {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DeckType DeckType { get; set; }

        public virtual ICollection<AddCardsToDeckModel> Cards { get; set; }

        }
    }
