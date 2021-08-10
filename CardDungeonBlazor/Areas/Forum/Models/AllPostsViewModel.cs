using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class AllPostsViewModel
        {

        public AllPostsViewModel ()
            {
            this.Posts = new List<PostServiceModel>();
            }

        public List<PostServiceModel> Posts { get; set; }
        }
    }
