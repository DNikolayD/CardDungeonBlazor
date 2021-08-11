using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class DecksViewModel
        {
        public DecksViewModel ()
            {
            this.Cards = new List<CardViewModel>();
            }

        public List<CardViewModel> Cards { get; set; }
        }
    }
