using CardDungeonBlazor.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Controllers
    {
    public class AllCategoriesController : ComponentBase
        {
        [Inject]
        protected ICategoriesService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AllCategoriesViewModel Model { get; set; }

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAllCategoriesViewModel(this.Service.GetAllCategories());
            base.OnInitialized();
            }

        public void RedirectToPosts ( string id )
            {
            this.Navigation.NavigateTo($"/posts/{id}/all");
            }

        public void RedirectToEdit ( string id )
            {
            this.Navigation.NavigateTo($"/categories/edit/{id}");
            }

        public void Delete ( string id )
            {
            this.Service.Delete(id);
            this.OnInitialized();
            }

        public void Redirect ()
            {
            this.Navigation.NavigateTo("/categories/add");
            }
        }
    }
