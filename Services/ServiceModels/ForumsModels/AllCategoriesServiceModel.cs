using System.Collections.Generic;

namespace Services.ServiceModels.ForumsModels
    {
    public class AllCategoriesServiceModel
        {
        public AllCategoriesServiceModel ()
            {
            this.Categories = new List<CategoryServiceModel>();
            }

        public List<CategoryServiceModel> Categories { get; set; }
        }
    }
