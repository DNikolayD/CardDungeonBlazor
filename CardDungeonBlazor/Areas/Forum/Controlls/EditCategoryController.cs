using CardDungeonBlazor.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Controllers
    {
    public class EditCategoryController : ComponentBase
        {
        [Inject]
        protected CategoriesService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public AddCategoryFormModel Model { get; set; }

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Model = this.Get.GetAddCategoryFormModel(this.Service.GetCategoryById(this.Id));
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Edit(this.Id, this.Get.GetAddCategoryServiceModel(this.Model));
            this.Navigation.NavigateTo("/categories/all");
            }
        }
    }
