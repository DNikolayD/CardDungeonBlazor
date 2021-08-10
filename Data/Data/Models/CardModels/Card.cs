﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;

namespace CardDungeonBlazor.Data.Models.CardModels
    {
    public class Card : BaseModel<string>
        {

        public Card ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.Decks = new HashSet<CardDeck>();
            }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CardTypeId { get; set; }

        public virtual CardType CardType { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public int Cost { get; set; }

        public int? Duration { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<CardDeck> Decks { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        }
    }
