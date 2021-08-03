using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controllers
{
    public class GameController : ComponentBase
    {
        [Inject]
        protected GameService Service { get; set; } 

        public GameViewModel Model { get; set; }

        protected override void OnInitialized() 
        {
            Model = new GameViewModel();
            Model.PlayerModel1.Deck = Service.GetDeck();
        }

        public void PlayCard(string cardId, string playerName)
        {
            Service.PlayCard(cardId, playerName, Model);
        }
    }
}
