using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class EditCardsController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected CardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public CardEditFomModel Model;

        protected override void OnInitialized ()
            {
            this.Model = this.Service.GetEditFomModel(this.Id);

            }

        public void Submit ()
            {
            this.Service.Edit(this.Id, this.Model);
            this.Navigation.NavigateTo("/cards/all");
            }
        }
    }
