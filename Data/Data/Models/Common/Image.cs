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
            }
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Img { get; set; }

        [Required]
        public string UploadedByUserId { get; set; }

        public virtual ApplicationUser UploadedByUser { get; set; }
        }
    }
