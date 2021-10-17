using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.UserModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class AddDeckController : ComponentBase
        {

        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        public DeckViewModel Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            base.OnInitialized();
            }

        public void Submit ()
            {
            DeckServiceModel deckServiceModel = MappingFromViewToService.DeckMapping(this.Model);
            UserServiceModel userServiceModel = this.Service.GetUserByName(this.HttpContext.HttpContext.User.Identity.Name);
            deckServiceModel.CreatedByUser = userServiceModel;
            this.Model = MappingFromServiceToView.DeckMapping(this.Service.Add(deckServiceModel));
            Navigation.NavigateTo($"/deck/addCards/{this.Model.Id}");
            }

        }
    }
