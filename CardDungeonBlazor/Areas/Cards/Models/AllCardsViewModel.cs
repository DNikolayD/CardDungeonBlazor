using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class AllCardsViewModel
        {

        public AllCardsViewModel ()
            {
            this.Cards = new List<CardViewModel>();
            }
        public List<CardViewModel> Cards { get; set; }
        }
    }
