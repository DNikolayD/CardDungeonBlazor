using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnInitialized()
        {
            Model = Service.GetCategoryById(this.Id);
            base.OnInitialized();
        }

        public void Submit()
        {
            Service.Edit(Id, Model);
            Navigation.NavigateTo("/categories/all");
        }
    }
}
