﻿using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
{
    public class AddDecksController : ComponentBase
    {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddDeckFormModel Model;

        protected override void OnInitialized()
        {
            Model = new();
        }

        public void Submit()
        {
            Service.Add(Model);
            string deckId = Service.GetId(Model.Name);
            Navigation.NavigateTo($"/deck/addCards/{deckId}");
        }
    }
}
