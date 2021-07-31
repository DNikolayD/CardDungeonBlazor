using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Model = new();
            Model.Cards = Service.GetAllCards().Cards;
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
            this.OnInitialized();
        }
    }
}
