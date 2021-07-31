﻿using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controllers
{
    public class CardsViewMoreController :ComponentBase
    {
        [Inject]
        public CardsService Service { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullCardViewModel Model;

        protected override void OnInitialized()
        {
            Model = Service.GetFullCardView(Id);
        }
        public void Redirect()
        {
            Navigation.NavigateTo("/cards/all");
        }
    }
}