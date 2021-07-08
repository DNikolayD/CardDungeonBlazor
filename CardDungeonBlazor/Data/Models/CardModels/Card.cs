using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using System;
using System.Collections.Generic;

namespace CardDungeonBlazor.Data.Models.CardModles
{
    public class Card : BaseModel<string>
    {

        public Card()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Decks = new HashSet<CardDeck>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public CardType CardType { get; set; }

        public int Value { get; set; }

        public int? Duration { get; set; }

        public ICollection<CardDeck> Decks { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
