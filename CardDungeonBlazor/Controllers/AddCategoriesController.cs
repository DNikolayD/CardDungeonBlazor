using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controllers
{
    public class AddCategoriesController : ComponentBase
    {
        [Inject]
        protected CategoriesService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddCategoryFormModel Model { get; set; }

        protected override void OnInitialized()
        {
            Model = new AddCategoryFormModel();
            base.OnInitialized();
        }

        public void Submit()
        {
            Service.Add(Model);
            Navigation.NavigateTo("/categories/all");
        }
    }
}
