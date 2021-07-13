using CardDungeonBlazor.Data.Models.CardModles;
using CardDungeonBlazor.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Data.Models.CardModels
{
    public class CardType : BaseModel<int>
    {

        public CardType()
        {
            this.Cards = new HashSet<Card>();
        }

        public string Name { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
