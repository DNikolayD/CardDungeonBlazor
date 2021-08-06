using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Model  = Service.GetAllCategories();
            base.OnInitialized();
        }

        public void RedirectToPosts(string id)
        {
            Navigation.NavigateTo($"/posts/{id}/all");
        }

        public void RedirectToEdit(string id)
        {
            Navigation.NavigateTo($"/categories/edit/{id}");
        }

        public void Delete(string id)
        {
            Service.Delete(id);
            this.OnInitialized();
        }

        public void Redirect()
        {
            Navigation.NavigateTo("/categories/add");
        }
    }
}
