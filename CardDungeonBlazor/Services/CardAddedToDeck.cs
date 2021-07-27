using CardDungeonBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
