using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using static DataConstraints.Deck;

namespace CardDungeonBlazor.Data.Models.CardModels
    {
    public class Deck : BaseModel<string>
        {

        public Deck ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new List<CardDeck>();
            this.Users = new HashSet<ApplicationUser>();
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
        public virtual List<CardDeck> Cards { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        }
    }
