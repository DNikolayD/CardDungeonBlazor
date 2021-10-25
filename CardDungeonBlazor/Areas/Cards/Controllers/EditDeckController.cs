using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.UserModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class EditDeckController : ComponentBase
        {

        [Inject]
        protected IDecksService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public DeckViewModel Model { get; set; }

        protected override void OnInitialized ()
            {
            DeckServiceModel deckServiceModel = this.Service.ShowFull(this.Id);
            this.Model = MappingFromServiceToView.DeckMapping(deckServiceModel);
            UserServiceModel userServiceModel = this.Service.GetUserByName(this.HttpContextAccessor.HttpContext.User.Identity.Name);
            this.Model.CreatedByUser = MappingFromServiceToView.UserMapping(userServiceModel);
            base.OnInitialized();
            }
        public void Submit ()
            {
            DeckServiceModel deckServiceModel = MappingFromViewToService.DeckMapping(this.Model);
            deckServiceModel.CreatedByUser = MappingFromViewToService.UserMapping(this.Model.CreatedByUser);
            this.Service.Edit(deckServiceModel);
            this.Navigation.NavigateTo($"/decks/cards/edit/{this.Id}");
            }

        }
    }
