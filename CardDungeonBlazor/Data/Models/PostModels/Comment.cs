using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using System.Collections.Generic;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class Comment : BaseModel<int>
    {

        public Comment()
        {
            this.Images = new HashSet<CommetImage>();
        }

        public string TextContent { get; set; }

        public int Likes { get; set; }

        public string PostedByUserId { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ICollection<CommetImage> Images { get; set; }
    }
}
