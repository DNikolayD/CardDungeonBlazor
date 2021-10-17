using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class EditDeckController : ComponentBase
        {

        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public DeckViewModel Model { get; set; }

        protected override void OnInitialized ()
            {
            DeckServiceModel deckServiceModel = this.Service.ShowFull(this.Id);
            this.Model = MappingFromServiceToView.DeckMapping(deckServiceModel);
            base.OnInitialized();
            }
        public void Submit ()
            {
            DeckServiceModel deckServiceModel = MappingFromViewToService.DeckMapping(this.Model);
            this.Service.Edit(deckServiceModel);
            this.Navigation.NavigateTo($"/decks/cards/edit/{this.Id}");
            }

        }
    }
