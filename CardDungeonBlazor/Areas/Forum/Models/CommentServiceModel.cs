using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class CommentServiceModel
        {
        public string Text { get; set; }

        public string Image { get; set; }

        public int Likes { get; set; }

        public string Username { get; set; }

        public string CreatedOn { get; set; }
        }
    }
