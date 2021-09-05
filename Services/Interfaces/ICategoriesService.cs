using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServiceModels.ForumsModels;

namespace Services.Interfaces
    {
    public interface ICategoriesService
        {
        void Add ( AddCategoryServiceModel model );

        AllCategoriesServiceModel GetAllCategories ();

        void Delete ( string id );

        AddCategoryServiceModel GetCategoryById ( string id );

        void Edit ( string id, AddCategoryServiceModel model );
        }
    }
