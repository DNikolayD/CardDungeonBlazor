using System.Collections.Generic;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class AllPostsViewModel
        {

        public AllPostsViewModel ()
            {
            this.Posts = new List<PostViewModel>();
            }

        public List<PostViewModel> Posts { get; set; }
        }
    }
