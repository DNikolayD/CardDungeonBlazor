using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class FullCardViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CardType { get; set; }

        public int Value { get; set; }

        public int Duration { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedOn { get; set; }
    }
}
