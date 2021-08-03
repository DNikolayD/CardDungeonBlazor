using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class DeckViewModel
    {
        public DeckViewModel()
        {
            Cards = new List<CardServiceModel>();
        }

        public List<CardServiceModel> Cards { get; set; }
    }
}
