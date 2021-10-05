using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.UserModels;
using static DataConstraints.Comment;

namespace ServiceLibrary.Models.ForumModels
    {
    public class CommentServiceModel : BaseServiceModel<string>
        {
        [Required]
        [MaxLength(TextMaxLength)]
        public string TextContent { get; set; }

        public List<ImageServiceModel> Images { get; set; }

        public int Likes { get; set; }

        public UserServiceModel PostedByUser { get; set; }

        public PostServiceModel Post { get; set; }

        }
    }
