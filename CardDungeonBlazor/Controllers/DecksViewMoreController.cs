using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controllers
{
    public class DecksViewMoreController : ComponentBase
    {
        [Inject]
        protected DecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullDeckViewModel Model;

        protected override void OnInitialized()
        {
            Model = Service.GetFullDeckView(Id);
        }
        public void Redirect()
        {
            Navigation.NavigateTo("/decks/all");
        }
    }
}
