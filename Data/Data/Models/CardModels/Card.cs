using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using static DataConstraints.Card;

namespace CardDungeonBlazor.Data.Models.CardModels
    {
    public class Card : BaseModel<string>
        {
        public Card ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.Decks = new List<CardDeck>();
            }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public int CardTypeId { get; set; }

        public virtual CardType CardType { get; set; }

        [Required]
        [Range(MinValue, MaxValue)]
        public int Value { get; set; }

        [Required]
        [Range(MinCost, MaxCost)]
        public int Cost { get; set; }

        public int Duration { get; set; }

        [Required]
        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public List<CardDeck> Decks { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        }
    }
