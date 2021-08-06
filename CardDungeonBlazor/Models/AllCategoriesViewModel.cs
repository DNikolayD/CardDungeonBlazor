using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class AllCategoriesViewModel
    {
        public AllCategoriesViewModel()
        {
            Categories = new List<CategoryServiceModel>();
        }

        public List<CategoryServiceModel> Categories { get; set; }
    }
}
