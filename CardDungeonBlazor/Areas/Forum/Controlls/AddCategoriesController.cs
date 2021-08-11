﻿using CardDungeonBlazor.Models;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Controllers
    {
    public class AddCategoriesController : ComponentBase
        {
        [Inject]
        protected CategoriesService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public AddCategoryFormModel Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new AddCategoryFormModel();
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Add(this.Model);
            this.Navigation.NavigateTo("/categories/all");
            }
        }
    }