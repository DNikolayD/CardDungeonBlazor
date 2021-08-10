using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class CardsViewMoreController : ComponentBase
        {
        [Inject]
        public CardsService Service { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullCardViewModel Model;

        protected override void OnInitialized ()
            {
            this.Model = this.Service.GetFullCardView(this.Id);
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/cards/all");
            }
        }
    }
