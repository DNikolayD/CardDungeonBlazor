using System.Collections.Generic;

namespace CardDungeonBlazor.Models
    {
    public class AllCategoriesViewModel
        {
        public AllCategoriesViewModel ()
            {
            this.Categories = new List<CategoryViewModel>();
            }

        public List<CategoryViewModel> Categories { get; set; }
        }
    }
