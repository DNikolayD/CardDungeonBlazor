using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;

namespace CardDungeonBlazor.Data.Models.PostModels
    {
    public class Post : BaseModel<string>
        {

        public Post ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TextContent { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string PostedByUserId { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string Images { get; set; }
        }
    }
