using System.Collections.Generic;

namespace CardDungeonBlazor.Models
{
    public class CardEditFomModel
    {
        public CardEditFomModel()
        {
            CardTypes = new List<CardTypeViewModel>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CardTypeId { get; set; }

        public virtual List<CardTypeViewModel> CardTypes { get; set; }

        public int Value { get; set; }
    }
}
