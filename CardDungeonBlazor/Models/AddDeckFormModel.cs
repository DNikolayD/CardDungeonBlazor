using CardDungeonBlazor.Data.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Models
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
