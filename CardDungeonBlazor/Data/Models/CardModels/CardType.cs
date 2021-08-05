using CardDungeonBlazor.Data.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.CardModels
{
    public class CardType : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

    }
}
