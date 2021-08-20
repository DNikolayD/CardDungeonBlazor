using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Data.Models.Common;
using static DataConstraints.CategoryConstraints;

namespace CardDungeonBlazor.Data.Models.PostModels
    {
    public class Category : BaseModel<string>
        {

        public Category ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.Posts = new HashSet<Post>();
            }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        }
    }
