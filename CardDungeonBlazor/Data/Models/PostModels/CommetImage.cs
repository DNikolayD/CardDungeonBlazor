using CardDungeonBlazor.Data.Models.Common;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class CommetImage
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
