using System.Collections.Generic;

namespace CardGame.Models
    {
    public class DeckModel
        {
        public DeckModel ()
            {
            this.Cards = new List<CardModel>();
            }

        public List<CardModel> Cards { get; set; }
        }
    }
