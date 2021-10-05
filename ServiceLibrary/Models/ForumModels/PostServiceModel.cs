using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.UserModels;
using static DataConstraints.Post;

namespace ServiceLibrary.Models.ForumModels
    {
    public class PostServiceModel : BaseServiceModel<string>
        {

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string TextContent { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public CategoryServiceModel Category { get; set; }

        [Required]
        public UserServiceModel PostedByUser { get; set; }

        public List<CommentServiceModel> Comments { get; set; }

        public List<ImageServiceModel> Images { get; set; }
        }
    }
