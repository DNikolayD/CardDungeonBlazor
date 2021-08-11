using System.Collections.Generic;

namespace Services.ServiceModels.ForumsModels
    {
    public class AllPostsServiceModel
        {
        public AllPostsServiceModel ()
            {
            this.Posts = new List<PostServiceModel>();
            }

        public List<PostServiceModel> Posts { get; set; }
        }
    }
