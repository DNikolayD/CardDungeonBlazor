using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

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
            this.Model = this.Service.GetCategoryById(this.Id);
            base.OnInitialized();
            }

        public void Submit()
            {
            this.Service.Edit(this.Id, this.Model);
            this.Navigation.NavigateTo("/categories/all");
            }
        }
    }
