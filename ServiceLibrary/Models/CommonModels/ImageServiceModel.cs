using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Models.CommonModels
    {
    public class ImageServiceModel : BaseServiceModel<string>
        {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Img { get; set; }

        [Required]
        public UserServiceModel UploadedByUser { get; set; }
        }
    }
