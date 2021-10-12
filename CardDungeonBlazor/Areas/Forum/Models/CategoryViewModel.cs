using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CardDungeonBlazor.Models;
using static DataConstraints.Category;

namespace CardDungeonBlazor.Areas.Forum.Models
    {
    public class CategoryViewModel : BaseViewModel<string>
        {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public List<PostViewModel> Posts { get; set; }
        }
    }
