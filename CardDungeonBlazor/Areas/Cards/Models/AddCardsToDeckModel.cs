﻿using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class AddCardsToDeckModel
        {

        public List<CardAddedToTheDeckViewModel> Cards { get; set; }

        public AddCardsToDeckModel ()
            {
            this.Cards = new List<CardAddedToTheDeckViewModel>();
            }
        }
    }