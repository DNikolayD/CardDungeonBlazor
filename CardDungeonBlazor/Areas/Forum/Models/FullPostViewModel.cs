using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class FullPostViewModel
        {

        public FullPostViewModel ()
            {
            this.Comments = new List<CommentViewModel>();
            }

        public string Title { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }

        public string Username { get; set; }

        public string Image { get; set; }

        public string CreatedOn { get; set; }

        public List<CommentViewModel> Comments { get; set; }
        }
    }
