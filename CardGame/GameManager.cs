using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Models;
using CardGame.Services;

namespace CardGame
    {
    public class GameManager
        {

        private PlayerModel player = new();
        private PlayerModel enemy = new();

        private bool gameIsOn = true;
        private bool isPlayer1sTurn = true;

        private GameEvents events;
        public GameManager ( PlayerModel player1, PlayerModel player2 )
            {
            this.Player1 = player1;
            this.Player2 = player2;
            }

        public PlayerModel Player1 { get; set; }
        public PlayerModel Player2 { get; set; }

        public string GetPlayerName ()
            {
            return this.player.Name;
            }
        public string GetEnemyName ()
            {
            return this.enemy.Name;
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
                            await this.Effect(paramsAray.FirstOrDefault());
                            }
                        else
                            {
                            return;
                            }
                        break;
                    case GameEvents.EndTurn:
                        this.EndTurn();
                        break;
                    case GameEvents.StartTurn:
                        this.StartTurn();
                        break;
                    case GameEvents.TookEffect:
                        this.CheckIfDead();
                        break;
                    case GameEvents.Died:
                        this.gameIsOn = !this.gameIsOn;
                        break;
                    default:
                        await Task.Delay(20);
                        return;
                    }
                }
            }
        private async Task Effect ( string id )
            {
            CardModel card = this.player.CardsInHeand.FirstOrDefault(c => c.Id == id);
            CardsService cardsService = new(card);
            List<PlayerModel> players;
            this.player.CardsInHeand.Remove(card);
            this.player.DescardPile.Add(card);
            players = cardsService.TakeEffect(this.player, this.enemy);
            this.UpdatePlayersStatus();
            await this.Update(GameEvents.TookEffect);
            }

        private void EndTurn ()
            {
            this.player.Energy = 3;
            this.player.Deck.Cards.AddRange(this.player.DescardPile);
            this.player.DescardPile.RemoveRange(0, this.player.DescardPile.Count);
            this.UpdatePlayersStatus();
            this.isPlayer1sTurn = !this.isPlayer1sTurn;
            }

        private void StartTurn ()
            {
            this.AssignPlayer();
            this.PoisonEffect();
            PlayersService playersService = new(this.player);
            while (this.player.CardsInHeand.Count != 5)
                {
                this.player = playersService.Draw();
                }
            this.UpdatePlayersStatus();
            }

        private async void CheckIfDead ()
            {
            if (this.Player1.Health <= 0 || this.Player2.Health <= 0)
                {
                await this.Update(GameEvents.Died);
                }
            }
        private void PoisonEffect ()
            {
            if (this.player.IsPoisoned)
                {
                this.player.Health -= this.player.TurnsPoisoned;
                this.player.TurnsPoisoned--;
                this.player.IsPoisoned = this.player.TurnsPoisoned != 0;
                this.UpdatePlayersStatus();
                }
            }
        private void AssignPlayer ()
            {
            if (this.isPlayer1sTurn)
                {
                this.player = this.Player1;
                this.enemy = this.Player2;
                }
            else
                {
                this.player = this.Player2;
                this.enemy = this.Player1;
                }
            }
        private void UpdatePlayersStatus ()
            {
            if (this.isPlayer1sTurn)
                {
                this.Player1 = this.player;
                this.Player2 = this.enemy;
                }
            else
                {
                this.Player2 = this.player;
                this.Player1 = this.enemy;
                }
            }
        }
    }
