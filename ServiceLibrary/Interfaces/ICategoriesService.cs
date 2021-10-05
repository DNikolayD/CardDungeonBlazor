using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.ForumModels;

namespace ServiceLibrary.Interfaces
    {
    public interface ICategoriesService
        {
        bool Add ( CategoryServiceModel categoryServiceModel );

        List<CategoryServiceModel> Show ();

        bool Edit ( CategoryServiceModel categoryServiceModel );

        bool Delete ( string categoyId );
        }
    }
