using System;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using static DataConstraints.CommentConstraints;

namespace CardDungeonBlazor.Data.Models.PostModels
    {
    public class Comment : BaseModel<string>
        {

        public Comment ()
            {
            this.Id = Guid.NewGuid().ToString();
            }

        [Required]
        [MaxLength(TextMaxLength)]
        public string TextContent { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public string PostedByUserId { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string Image { get; set; }
        }
    }
