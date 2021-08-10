using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class AddPostFormModel
        {
        public string Title { get; set; }

        public string TextContent { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }

        public int Likes { get; set; }

        public string CategoryId { get; set; }
        }
    }
