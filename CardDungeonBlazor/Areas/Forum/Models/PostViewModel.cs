using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Models;
using static DataConstraints.Post;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class PostViewModel : BaseViewModel<string>
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
        public CategoryViewModel Category { get; set; }

        [Required]
        public UserViewModel PostedByUser { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public List<ImageViewModel> Images { get; set; }
        }
    }
