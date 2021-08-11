using System.Collections.Generic;

namespace Services.ServiceModels.ForumsModels
    {
    public class FullPostServiceModel
        {
        public FullPostServiceModel ()
            {
            this.Comments = new List<CommentServiceModel>();
            }

        public string Title { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }

        public string Username { get; set; }

        public string Image { get; set; }

        public string CreatedOn { get; set; }

        public List<CommentServiceModel> Comments { get; set; }
        }
    }
