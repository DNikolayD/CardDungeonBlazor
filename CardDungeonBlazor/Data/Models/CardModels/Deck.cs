using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using System;
using System.Collections.Generic;

namespace CardDungeonBlazor.Data.Models.CardModles
{
    public class Deck : BaseModel<string>
    {

        public Deck()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new HashSet<CardDeck>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DeckType DeckType { get; set; }

        public virtual ICollection<CardDeck> Cards  { get; set; }

        public string CreatedByUserId { get; set; }

        // public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
