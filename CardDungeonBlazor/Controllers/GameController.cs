using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame;

namespace CardDungeonBlazor.Controllers
{
    public class GameController : ComponentBase
    {
        [Inject]
        protected GameService Service { get; set; } 

        public GameViewModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = new GameViewModel();
            Model.PlayerModel1.Name = "player1";
            Model.PlayerModel2.Name = "player2";
            Service.GameManager = new GameManager(Service.GetPlayer(Model, Model.PlayerModel1.Name), Service.GetPlayer(Model, Model.PlayerModel2.Name));
            Model.PlayerModel1.Deck = Service.GetDeck(Model.PlayerModel1.Name);
            Model.PlayerModel2.Deck = Service.GetDeck(Model.PlayerModel2.Name);
            Model.PlayerModel1.CardsInHeand = await Service.GetCardsInHand();
        }


        public async Task PlayCard(string cardId, string playerName)
        {
            await Service.PlayCard(cardId, playerName, Model);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            foreach (var deck in Model.PlayerModel2.Deck.Cards)
            {
                deck.Offcet = 0;
            }
            foreach (var deck in Model.PlayerModel1
                .Deck.Cards)
            {
                deck.Offcet = 0;
            }
            base.OnAfterRender(firstRender);
        }

        public async Task EndTurn()
        {
            await Service.EndTurn();
            if (Service.GameManager.player.Name == Model.PlayerModel1.Name)
            {
               Model.PlayerModel1.CardsInHeand = await Service.GetCardsInHand();
            }
            else
            {
                Model.PlayerModel2.CardsInHeand = await Service.GetCardsInHand(); ;
            }
        }
    }
}
