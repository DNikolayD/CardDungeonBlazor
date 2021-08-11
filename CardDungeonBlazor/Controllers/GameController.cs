using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using CardGame;
using Microsoft.AspNetCore.Components;
using Services.ServiceModels.GameModels;
using Services.Services;

namespace CardDungeonBlazor.Controllers
    {
    public class GameController : ComponentBase
        {
        [Inject]
        protected GameService Service { get; set; }

        public GameViewModel Model { get; set; }

        public GetViewModelsFromServiceModels Get;

        protected override async Task OnInitializedAsync ()
            {
            this.Get = new();
            this.Model = new GameViewModel();
            this.Model.PlayerModel1.Name = "player1";
            this.Model.PlayerModel2.Name = "player2";
            GameServiceModel gameServiceModel = this.Get.GetGameServiceModel(this.Model);
            this.Service.GameManager = new GameManager(GameService.GetPlayer(gameServiceModel, this.Model.PlayerModel1.Name), GameService.GetPlayer(gameServiceModel, this.Model.PlayerModel2.Name));
            this.Model.PlayerModel1.Deck = this.Get.GetDecksViewModel(this.Service.GetDeck(this.Model.PlayerModel1.Name));
            this.Model.PlayerModel2.Deck = this.Get.GetDecksViewModel(this.Service.GetDeck(this.Model.PlayerModel2.Name));
            this.Model.PlayerModel1.CardsInHeand = this.Get.GetCardViewModels(await this.Service.GetCardsInHand());
            }


        public async Task PlayCard ( string cardId, string playerName )
            {
            await this.Service.PlayCard(cardId, playerName, this.Get.GetGameServiceModel(this.Model));
            }

        protected override void OnAfterRender ( bool firstRender )
            {
            foreach (CardViewModel deck in this.Model.PlayerModel2.Deck.Cards)
                {
                deck.Offcet = 0;
                }
            foreach (CardViewModel deck in this.Model.PlayerModel1
                  .Deck.Cards)
                {
                deck.Offcet = 0;
                }
            base.OnAfterRender(firstRender);
            }

        public async Task EndTurn ()
            {
            await this.Service.EndTurn();
            if (this.Service.GameManager.player.Name == this.Model.PlayerModel1.Name)
                {
                this.Model.PlayerModel1.CardsInHeand = this.Get.GetCardViewModels(await this.Service.GetCardsInHand());
                }
            else
                {
                this.Model.PlayerModel2.CardsInHeand = this.Get.GetCardViewModels(await this.Service.GetCardsInHand());
                }
            }
        }
    }
