using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controllers
{
    public class AllDecksController : ComponentBase
    {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AllDeckViewModel Model;

        protected override void OnInitialized()
        {
            Model = new();
            Model.Decks = Service.GetAll().Decks;

        }

        public void RedirectToFullView(string id)
        {
            Navigation.NavigateTo($"/deck/show/{id}");
        }

        public void RedirectToEdit(string id)
        {
            Navigation.NavigateTo($"/deck/edit/{id}");
        }

        public void Delete(string id)
        {
            Service.Delete(id);
            OnInitialized();
        }

        public void Redirect()
        {
            Navigation.NavigateTo("/decks/add");
        }


    }
}
