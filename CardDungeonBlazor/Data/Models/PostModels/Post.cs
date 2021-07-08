using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using System.Collections.Generic;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class Post : BaseModel<int>
    {

        public Post()
        {
            this.Images = new HashSet<PostImage>();
        }

        public string Title { get; set; }

        public string TextContent { get; set; }

        public int Likes { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string PostedByUserId { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public virtual ICollection<PostImage> Images { get; set; }
    }
}
