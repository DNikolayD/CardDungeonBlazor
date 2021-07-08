using CardDungeonBlazor.Data.Models.Common;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class PostImage
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
