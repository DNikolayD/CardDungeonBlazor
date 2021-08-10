using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Models;
using CardGame.Services;

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
        public GameManager ( PlayerModel player1, PlayerModel player2 )
            {
            this.player1 = player1;
            this.player2 = player2;
            }


        public async Task Update ( GameEvents events, params string[] paramsAray )
            {
            if (this.gameIsOn)
                {
                switch (events)
                    {

                    case GameEvents.SelectCard:
                        if (this.events != events)
                            {
                            this.events = events;
                            this.Effect(paramsAray.FirstOrDefault());
                            }
                        else
                            {
                            return;
                            }
                        break;
                    case GameEvents.EndTurn:
                        this.player1.Energy = 3;
                        this.player2.Energy = 3;
                        this.isPlayer1sTurn = !this.isPlayer1sTurn;
                        if (this.isPlayer1sTurn)
                            {
                            this.player1.Deck.Cards.AddRange(this.player1.CardsInHeand);
                            this.player1.CardsInHeand.RemoveRange(0, this.player1.CardsInHeand.Count);
                            this.player = this.player1;
                            }
                        else
                            {
                            this.player1.Deck.Cards.AddRange(this.player1.CardsInHeand);
                            this.player1.CardsInHeand.RemoveRange(0, this.player1.CardsInHeand.Count);
                            this.player = this.player2;
                            }
                        break;
                    case GameEvents.StartTurn:
                        if (this.player.CardsInHeand.Count == 5)
                            {
                            return;
                            }
                        this.StartTurn();
                        break;
                    case GameEvents.TookEffect:
                        if (this.events != events)
                            {
                            this.events = events;
                            this.CheckIfDead();
                            }
                        else
                            {
                            return;
                            }
                        break;
                    case GameEvents.Died:
                        this.gameIsOn = !this.gameIsOn;
                        break;
                    default:
                        await Task.Delay(20);
                        return;
                    }
                }

            /* while (gameIsOn)
		 {

			 await Task.Delay(20);
		 }
		*/
            }
        private async void Effect ( string id )
            {
            CardModel card = this.player.Deck.Cards.FirstOrDefault(c => c.Id == id);
            CardsService cardsService = new(card);
            List<PlayerModel> playerStates;
            if (this.isPlayer1sTurn)
                {

                playerStates = cardsService.TakeEffect(this.player1, this.player2);

                }
            else
                {
                playerStates = cardsService.TakeEffect(this.player2, this.player1);
                }
            this.player1 = playerStates.FirstOrDefault(x => x.Name == this.player1.Name);
            this.player2 = playerStates.FirstOrDefault(x => x.Name == this.player2.Name);
            await this.Update(GameEvents.TookEffect);
            }

        private void StartTurn ()
            {
            if (this.isPlayer1sTurn)
                {
                this.player = this.player1;
                }
            else
                {
                this.player = this.player2;
                }
            PlayersService playersService = new(this.player);
            this.player = playersService.Draw();
            if (this.player.Name == this.player1.Name)
                {
                this.player1 = this.player;
                }
            else if (this.player.Name == this.player2.Name)
                {
                this.player2 = this.player;
                }
            }

        public async void CheckIfDead ()
            {
            if (this.player1.Health <= 0 || this.player2.Health <= 0)
                {
                await this.Update(GameEvents.Died);
                }
            else
                {
                await this.Update(this.events);
                }
            }

        public void AssignDecks ( DeckModel deckModel1, DeckModel deckModel2 )
            {
            this.player1.Deck = deckModel1;
            this.player2.Deck = deckModel2;
            }
        }
    }
