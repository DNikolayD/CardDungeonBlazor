﻿namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class CardViewModel
        {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string CardType { get; set; }

        public int Cost { get; set; }

        public int Value { get; set; }

        public int Offcet { get; set; } = 0;
        }
    }