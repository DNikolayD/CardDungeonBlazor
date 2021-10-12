using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Models;
using static DataConstraints.Deck;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class DeckViewModel : BaseViewModel<string>
        {
        public DeckViewModel ()
            {
            this.Cards = new();
            this.Users = new();
            }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DeckType DeckType { get; set; }

        [Required]
        public List<CardViewModel> Cards { get; set; }

        [Required]
        public UserViewModel CreatedByUser { get; set; }

        public virtual List<UserViewModel> Users { get; set; }
        }
    }
