using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;

namespace CardDungeonBlazor.Data.Models.CardModels
    {
    public class CardType : BaseModel<int>
        {
        [Required]
        public string Name { get; set; }

        }
    }
