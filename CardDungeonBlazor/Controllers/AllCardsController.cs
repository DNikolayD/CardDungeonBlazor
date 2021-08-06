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
            Model  = Service.GetAllCards();
        }

        public void Redirect()
        {
            Navigation.NavigateTo("/cards/add");
        }

        public void RedirectToFullView(string id)
        {
            Navigation.NavigateTo($"/card/show/{id}");
        }

        public void RedirectToEdit(string id)
        {
            Navigation.NavigateTo($"/card/edit/{id}");
        }

        public void Delete(string id)
        {
            Service.Delete(id);
            OnInitialized();
        }
    }
}
