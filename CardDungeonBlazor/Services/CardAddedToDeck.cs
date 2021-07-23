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
            this.Cards = new List<KeyValuePair<CardServiceModel, int>>();
        }
        public List<KeyValuePair<CardServiceModel, int>> Cards { get; set; }
    }
}
