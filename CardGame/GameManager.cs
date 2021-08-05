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
        public PlayerModel player1;
        public PlayerModel player2;

        public PlayerModel player = new();
        private bool gameIsOn = true;
        private bool isPlayer1sTurn = true;

        private GameEvents events;
        public GameManager(PlayerModel player1, PlayerModel player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }


        public async Task Update(GameEvents events, params string[] paramsAray)
        {
            if (gameIsOn)
            {
                switch (events)
                {

                    case GameEvents.SelectCard:
                        if (this.events != events)
                        {
                            this.events = events;
                            Effect(paramsAray.FirstOrDefault());
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case GameEvents.EndTurn:
                        player1.Energy = 3;
                        player2.Energy = 3;
                        isPlayer1sTurn = !isPlayer1sTurn;
                        if (isPlayer1sTurn)
                        {
                            player1.Deck.Cards.AddRange(player1.CardsInHeand);
                            player1.CardsInHeand.RemoveRange(0, player1.CardsInHeand.Count);
                            player = player1;
                        }
                        else
                        {
                            player1.Deck.Cards.AddRange(player1.CardsInHeand);
                            player1.CardsInHeand.RemoveRange(0, player1.CardsInHeand.Count);
                            player = player2;
                        }
                        break;
                    case GameEvents.StartTurn:
                        if (player.CardsInHeand.Count == 5)
                        {
                            return;
                        }
                        StartTurn();
                        break;
                    case GameEvents.TookEffect:
                        if (this.events != events)
                        {
                            this.events = events;
                            CheckIfDead();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case GameEvents.Died:
                        gameIsOn = !gameIsOn;
                        break;
                    default:
                        return;
                        await Task.Delay(20);
                }
            }
            
           /* while (gameIsOn)
            {
                
                await Task.Delay(20);
            }
           */
        }
        private async void Effect(string id)
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
            await this.Update(GameEvents.TookEffect); 
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
            player = playersService.Draw();
            if (player.Name == player1.Name)
            {
                player1 = player;
            }
            else if(player.Name == player2.Name)
            {
                player2 = player;
            }
        }

        public async void CheckIfDead()
        {
            if (player1.Health <= 0 || player2.Health <= 0)
            {
                await this.Update(GameEvents.Died);
            }
            else
            {
                await this.Update(events);
            }
        }

        public void AssignDecks(DeckModel deckModel1, DeckModel deckModel2)
        {
            player1.Deck = deckModel1;
            player2.Deck = deckModel2;
        }
    }
}
