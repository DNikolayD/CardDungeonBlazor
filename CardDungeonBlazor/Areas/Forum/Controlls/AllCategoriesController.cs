using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
    {
    public class AllCategoriesController : ComponentBase
        {
        [Inject]
        protected CategoriesService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AllCategoriesViewModel Model { get; set; }

        protected override void OnInitialized()
            {
            this.Model = this.Service.GetAllCategories();
            base.OnInitialized();
            }

        public void RedirectToPosts(string id)
            {
            this.Navigation.NavigateTo($"/posts/{id}/all");
            }

        public void RedirectToEdit(string id)
            {
            this.Navigation.NavigateTo($"/categories/edit/{id}");
            }

        public void Delete(string id)
            {
            this.Service.Delete(id);
            this.OnInitialized();
            }

        public void Redirect()
            {
            this.Navigation.NavigateTo("/categories/add");
            }
        }
    }
