using CardGame.Models;
using CardGame.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class GameManager
    {
        private PlayerModel player1;
        private PlayerModel player2;

        private PlayerModel player = new();
        private bool gameIsOn = true;
        private bool isPlayer1sTurn = true;
        public GameManager(PlayerModel player1, PlayerModel player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }


        public async void Update(GameEvents events, params string[] paramsAray)
        {
            
            while (gameIsOn)
            {
                switch (events)
                {
                    case GameEvents.SelectCard: Effect(paramsAray.FirstOrDefault());
                        break;
                    case GameEvents.EndTurn: isPlayer1sTurn = !isPlayer1sTurn;
                        break;
                    case GameEvents.StartTurn: StartTurn();                       
                        break;
                    case GameEvents.TookEffect: CheckIfDead(player);
                        break;
                    case GameEvents.Died: gameIsOn = !gameIsOn;
                        break;
                    default:
                        break;
                }
                await Task.Delay(20);
            }
        }
        private void Effect(string id)
        {
            var card = player.Deck.Cards.FirstOrDefault(c => c.Id == id);
            CardsService cardsService = new(card);
            List<PlayerModel> playerStates; 
            if (isPlayer1sTurn)
            {
                playerStates = cardsService.TakeEffect(player1, player2);

            }
            else
            {
                playerStates = cardsService.TakeEffect(player2, player1);
            }
            player1 = playerStates.FirstOrDefault(x => x.Name == player1.Name);
            player2 = playerStates.FirstOrDefault(x => x.Name == player2.Name);
            this.Update(GameEvents.TookEffect); 
        }

        private void StartTurn()
        {
            if (isPlayer1sTurn)
            {
                player = player1; 
            }       
            else
            {
                player = player2;
            }
            PlayersService playersService = new(player);
            playersService.Draw();
        }

        public void CheckIfDead(PlayerModel player)
        {
            if (player.Health <= 0)
            {
                this.Update(GameEvents.Died);
            }
        }
    }
}
