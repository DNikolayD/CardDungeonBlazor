using CardDungeonBlazor.Data.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class Category : BaseModel<int>
    {

        public Category()
        {
            Posts = new HashSet<Post>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
