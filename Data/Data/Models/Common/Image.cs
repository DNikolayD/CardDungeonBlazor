using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;

namespace Data.Data.Models.Common
    {
    public class Image : BaseModel<string>
        {
        public Image ()
            {
            this.Id = Guid.NewGuid().ToString();
           // this.CommentId = string.Empty;
           // this.Comment = new();
            }
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Img { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

       // public string? CardId { get; set; }

       // public virtual Card? Card { get; set; }

       // public string? PostId { get; set; }

       // public virtual Post? Post { get; set; }

       // public string? CommentId { get; set; }

       // public virtual Comment? Comment { get; set; }
        }
    }
