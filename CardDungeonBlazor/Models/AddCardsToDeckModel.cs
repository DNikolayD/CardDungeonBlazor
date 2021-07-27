using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class AddCardsToDeckModel
    {

        public List<CardAddedToTheDeckViewModel> Cards { get; set; }

        public AddCardsToDeckModel()
        {
            Cards = new List<CardAddedToTheDeckViewModel>();
        }
    }
}
