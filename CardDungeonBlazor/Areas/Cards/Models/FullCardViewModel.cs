﻿namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class FullCardViewModel
        {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Value { get; set; }

        public int Cost { get; set; }

        public int Duration { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedOn { get; set; }
        }
    }
