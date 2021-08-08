using System.Collections.Generic;

namespace CardDungeonBlazor.Models
    {
    public class AllCardsViewModel
        {

        public AllCardsViewModel()
            {
            this.Cards = new List<CardServiceModel>();
            }
        public List<CardServiceModel> Cards { get; set; }
        }
    }
