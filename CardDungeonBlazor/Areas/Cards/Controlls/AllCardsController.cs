using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
    {
    public class AllCardsController : ComponentBase
        {
        [Inject]
        protected CardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AllCardsViewModel Model;

        protected override void OnInitialized()
            {
            this.Model = this.Service.GetAllCards();
            }

        public void Redirect()
            {
            this.Navigation.NavigateTo("/cards/add");
            }

        public void RedirectToFullView(string id)
            {
            this.Navigation.NavigateTo($"/card/show/{id}");
            }

        public void RedirectToEdit(string id)
            {
            this.Navigation.NavigateTo($"/card/edit/{id}");
            }

        public void Delete(string id)
            {
            this.Service.Delete(id);
            this.OnInitialized();
            }
        }
    }
