using System.Collections.Generic;

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
