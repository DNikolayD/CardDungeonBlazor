using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CommonModels;
using static DataConstraints.Category;

namespace ServiceLibrary.Models.ForumModels
    {
    public class CategoryServiceModel : BaseServiceModel<string>
        {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public List<PostServiceModel> Posts { get; set; }
        }
    }
