using CardDungeonBlazor.Data.Models.PostModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.Common
{
    public class Image : BaseModel<string>
    {

        public Image()
        {
            Id = Guid.NewGuid().ToString();
            Cards = new HashSet<CardImage>();
            Posts = new HashSet<PostImage>();
            Commets = new HashSet<CommetImage>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<CardImage> Cards { get; set; }

        public virtual ICollection<PostImage> Posts { get; set; }

        public virtual ICollection<CommetImage> Commets { get; set; }
    }
}
