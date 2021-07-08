using CardDungeonBlazor.Data.Models.CardModles;

namespace CardDungeonBlazor.Data.Models.Common
{
    public class CardImage
    {
        public int Id { get; set; }

        public string CardId { get; set; }

        public virtual Card Card { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
