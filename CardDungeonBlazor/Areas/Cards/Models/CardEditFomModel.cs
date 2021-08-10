﻿using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class CardEditFomModel
        {
        public CardEditFomModel ()
            {
            this.CardTypes = new List<CardTypeViewModel>();
            }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CardTypeId { get; set; }

        public virtual List<CardTypeViewModel> CardTypes { get; set; }

        public int Value { get; set; }

        public int Cost { get; set; }
        }
    }
