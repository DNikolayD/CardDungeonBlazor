using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class AllCardsViewModel
        {

        public AllCardsViewModel ()
            {
            this.Cards = new List<CardServiceModel>();
            }
        public List<CardServiceModel> Cards { get; set; }
        }
    }
