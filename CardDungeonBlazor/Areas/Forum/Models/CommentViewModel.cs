using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Models;
using static DataConstraints.Comment;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class CommentViewModel : BaseViewModel<string>
        {
        [Required]
        [MaxLength(TextMaxLength)]
        public string TextContent { get; set; }

        public List<ImageViewModel> Images { get; set; }

        public int Likes { get; set; }

        public UserViewModel PostedByUser { get; set; }

        public PostViewModel Post { get; set; }
        }
    }
