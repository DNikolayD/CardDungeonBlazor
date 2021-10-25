using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
    {
    public class RewardController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string EnemyDeck { get; set; }

        [Parameter]
        public string Energy { get; set; }

        [Parameter]
        public string Draw { get; set; }

        [Parameter]
        public string Health { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public void ChooseDraw ()
            {
            int drawPoints = int.Parse(this.Draw);
            drawPoints++;
            int deckPlace = int.Parse(this.EnemyDeck);
            deckPlace++;
            this.Navigation.NavigateTo($"/game/main/{this.Id}/{deckPlace}/{drawPoints}/{this.Energy}/{this.Health}");
            }
        public void ChooseEnergy ()
            {
            int energyPoints = int.Parse(this.Energy);
            energyPoints++;
            int deckPlace = int.Parse(this.EnemyDeck);
            deckPlace++;
            this.Navigation.NavigateTo($"/game/main/{this.Id}/{deckPlace}/{this.Draw}/{energyPoints}/{this.Health}");
            }
        public void ChooseHealth ()
            {
            int healthPoints = int.Parse(this.Health);
            healthPoints += 50;
            int deckPlace = int.Parse(this.EnemyDeck);
            deckPlace++;
            this.Navigation.NavigateTo($"/game/main/{this.Id}/{deckPlace}/{this.Draw}/{this.Energy}/{healthPoints}");
            }

        }
    }
