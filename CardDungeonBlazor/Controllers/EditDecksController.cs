﻿using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controllers
{
    public class EditDecksController : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddDeckFormModel Model;

        protected override void OnInitialized()
        {
            Model = Service.GetDeck(Id);
        }

        public void Submit()
        {
            Service.Edit(Id, Model);
            string deckId = Service.GetId(Model.Name);
            Navigation.NavigateTo($"/deck/addCards/{deckId}");
        }
    }
}