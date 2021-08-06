using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.PostModels
{
    public class Comment : BaseModel<string>
    {

        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string TextContent { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public string PostedByUserId { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual string Image { get; set; }
    }
}
