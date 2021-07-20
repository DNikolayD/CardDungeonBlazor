using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class AddCardFormModel
    {
        public AddCardFormModel()
        {
            CardTypes = new List<CardTypeViewModel>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CardTypeId { get; set; }

        public virtual List<CardTypeViewModel> CardTypes { get; set; }

        public int Value { get; set; }

    }
}
