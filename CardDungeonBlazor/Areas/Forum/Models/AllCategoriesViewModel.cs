using System.Collections.Generic;

namespace CardDungeonBlazor.Models
    {
    public class AllCategoriesViewModel
        {
        public AllCategoriesViewModel ()
            {
            this.Categories = new List<CategoryServiceModel>();
            }

        public List<CategoryServiceModel> Categories { get; set; }
        }
    }
