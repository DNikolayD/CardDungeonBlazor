using CardDungeonBlazor.Models;
using System.Collections.Generic;

namespace CardDungeonBlazor.Services
{
    public class CardAddedToDeck
    {
        public CardAddedToDeck()
        {
            Cards = new List<CardAddedToTheDeckViewModel>();
        }
        public List<CardAddedToTheDeckViewModel> Cards { get; set; }
    }
}
