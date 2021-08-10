using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class AddCardsController : ComponentBase
        {
        [Inject]
        protected CardsService Service { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public AddCardFormModel Model { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            this.Model.CardTypes = this.Service.GetCardTypeViewModels();
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Add(this.Model);
            this.NavigationManager.NavigateTo("/cards/all");
            }
        }
    }
