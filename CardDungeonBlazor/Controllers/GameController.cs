using System.Threading.Tasks;
using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using CardGame;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Controllers
    {
    public class GameController : ComponentBase
        {
        [Inject]
        protected GameService Service { get; set; }

        public GameViewModel Model { get; set; }

        protected override async Task OnInitializedAsync()
            {
            this.Model = new GameViewModel();
            this.Model.PlayerModel1.Name = "player1";
            this.Model.PlayerModel2.Name = "player2";
            this.Service.GameManager = new GameManager(this.Service.GetPlayer(this.Model, this.Model.PlayerModel1.Name), this.Service.GetPlayer(this.Model, this.Model.PlayerModel2.Name));
            this.Model.PlayerModel1.Deck = this.Service.GetDeck(this.Model.PlayerModel1.Name);
            this.Model.PlayerModel2.Deck = this.Service.GetDeck(this.Model.PlayerModel2.Name);
            this.Model.PlayerModel1.CardsInHeand = await this.Service.GetCardsInHand();
            }


        public async Task PlayCard(string cardId, string playerName)
            {
            await this.Service.PlayCard(cardId, playerName, this.Model);
            }

        protected override void OnAfterRender(bool firstRender)
            {
            foreach (CardServiceModel deck in this.Model.PlayerModel2.Deck.Cards)
                {
                deck.Offcet = 0;
                }
            foreach (CardServiceModel deck in this.Model.PlayerModel1
                .Deck.Cards)
                {
                deck.Offcet = 0;
                }
            base.OnAfterRender(firstRender);
            }

        public async Task EndTurn()
            {
            await this.Service.EndTurn();
            if (this.Service.GameManager.player.Name == this.Model.PlayerModel1.Name)
                {
                this.Model.PlayerModel1.CardsInHeand = await this.Service.GetCardsInHand();
                }
            else
                {
                this.Model.PlayerModel2.CardsInHeand = await this.Service.GetCardsInHand();
                }
            }
        }
    }
