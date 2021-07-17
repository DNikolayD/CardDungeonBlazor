using CardDungeonBlazor.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Data.Models.CardModels
{
    public class CardType : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

    }
}
