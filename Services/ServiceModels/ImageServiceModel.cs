using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.User;

namespace Services.ServiceModels
    {
    public class ImageServiceModel
        {
        public ImageServiceModel ()
            {
            this.Id = Guid.NewGuid().ToString();
            }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Img { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        }
    }
