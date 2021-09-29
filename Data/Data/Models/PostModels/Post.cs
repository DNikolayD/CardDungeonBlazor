using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using static DataConstraints.Post;

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
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
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

        public virtual List<Image> Images { get; set; }
        }
    }
