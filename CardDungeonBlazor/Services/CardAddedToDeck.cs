using System.Collections.Generic;
using CardDungeonBlazor.Models;

namespace CardDungeonBlazor.Services
    {
    public class CardAddedToDeck
        {
        public CardAddedToDeck()
            {
            this.Cards = new List<CardAddedToTheDeckViewModel>();
            }
        public List<CardAddedToTheDeckViewModel> Cards { get; set; }
        }
    }
