using CardDungeonBlazor.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Controllers
    {
    public class AddCategoriesController : ComponentBase
        {
        [Inject]
        protected ICategoriesService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddCategoryFormModel Model { get; set; }

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = new AddCategoryFormModel();
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Add(this.Get.GetAddCategoryServiceModel(this.Model));
            this.Navigation.NavigateTo("/categories/all");
            }
        }
    }
