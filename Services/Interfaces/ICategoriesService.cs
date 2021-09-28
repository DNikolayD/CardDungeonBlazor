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
