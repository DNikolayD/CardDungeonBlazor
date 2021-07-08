using CardDungeonBlazor.Data.Models.Common;
using System.Collections.Generic;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class Category : BaseModel<int>
    {

        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
