using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class DeckModel
    {
        public DeckModel()
        {
            Cards = new List<CardModel>();
        }

        public List<CardModel> Cards { get; set; }
    }
}
