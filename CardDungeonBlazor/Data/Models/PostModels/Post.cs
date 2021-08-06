using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class Post : BaseModel<string>
    {

        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            Comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TextContent { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string PostedByUserId { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual string Images { get; set; }
    }
}
