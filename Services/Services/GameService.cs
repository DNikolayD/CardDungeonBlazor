using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardGame;
using CardGame.Models;
using Services.Interfaces;
using Services.ServiceModels.CardsModels;
using Services.ServiceModels.GameModels;

namespace Services.Services
    {
    public class GameService : IGameService
        {
        private readonly ApplicationDbContext data;

        private readonly PlayerServiceModel player = new();
        private readonly PlayerServiceModel enemy = new();

        public GameService ( ApplicationDbContext data )
            {
            this.data = data;
            }

        public GameManager GameManager { get; set; }

        public EnemyScript Enemy { get; set; }

        public async Task<GameServiceModel> PlayCard ( string cardId, string playerName, GameServiceModel game )
            {
            PlayerModel player = GetPlayer(game, playerName);
            CardModel playedCard = player.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
            if (player.Energy < playedCard.Cost)
                {
                return game;
                }
            await this.GameManager.Update(GameEvents.SelectCard, new string[] { cardId });
            game.PlayerModel1.Health = this.GameManager.Player1.Health;
            game.PlayerModel2.Health = this.GameManager.Player2.Health;
            game.PlayerModel1.Energy = this.GameManager.Player1.Energy;
            game.PlayerModel2.Energy = this.GameManager.Player2.Energy;
            game.PlayerModel1.Deffence = this.GameManager.Player1.Deffence;
            game.PlayerModel2.Deffence = this.GameManager.Player2.Deffence;
            if (game.PlayerModel1.CardsInHeand.Any(c => c.Id == cardId) && game.PlayerModel1.Name == playerName)
                {
                game.PlayerModel1.CardsInHeand.Remove(game.PlayerModel1.CardsInHeand.Find(c => c.Id == cardId));
                }
            else
                {
                game.PlayerModel2.CardsInHeand.Remove(game.PlayerModel2.CardsInHeand.Find(c => c.Id == cardId));
                }
            return game;
            }
        public DecksServiceModel GetDeck ( string playerName, string id )
            {
            DecksServiceModel viewModel = new();
            IQueryable<CardDeck> deck = this.data.CardDecks.Where(cd => cd.DeckId == id);
            foreach (CardDeck cardDeck in deck)
                {
                Card card = this.data.Cards.FirstOrDefault(c => c.Id == cardDeck.CardId);
                viewModel.Cards.Add
                (
                new CardServiceModel
                    {
                    Id = card.Id,
                    CardType = this.data.CardTypes.FirstOrDefault(ct => ct.Id == card.CardTypeId).Name,
                    Name = card.Name,
                    Cost = card.Cost,
                    // ImageUrl = card.ImageUrl,
                    Value = card.Value,
                    }
                );
                }
            foreach (CardServiceModel cardService in viewModel.Cards)
                {
                TypeModel model = new();
                if (cardService.CardType == "Attack")
                    {
                    model = TypeModel.Attack;
                    }
                else if (cardService.CardType == "Heal")
                    {
                    model = TypeModel.Heal;
                    }
                else if (cardService.CardType == "Defence")
                    {
                    model = TypeModel.Deffence;
                    }
                else if (cardService.CardType == "Poison")
                    {
                    model = TypeModel.Poison;
                    };
                if (playerName == this.GameManager.Player1.Name)
                    {
                    this.GameManager.Player1.Deck.Cards.Add(
                    new CardModel
                        {
                        Cost = cardService.Cost,
                        Id = cardService.Id,
                        Name = cardService.Name,
                        Type = model,
                        Value = cardService.Value,
                        }
                    );
                    }
                else
                    {
                    this.GameManager.Player2.Deck.Cards.Add(
                    new CardModel
                        {
                        Cost = cardService.Cost,
                        Id = cardService.Id,
                        Name = cardService.Name,
                        Type = model,
                        Value = cardService.Value,
                        }
                    );
                    }
                }
            return viewModel;
            }
        public static PlayerModel GetPlayer ( GameServiceModel game, string playerName )
            {
            PlayerModel player;
            PlayerServiceModel playerView;
            if (game.PlayerModel1.Name == playerName)
                {
                playerView = game.PlayerModel1;
                }
            else
                {
                playerView = game.PlayerModel2;

                }
            List<CardModel> cards = new();
            DeckModel deck = new();
            foreach (CardServiceModel card in playerView.CardsInHeand)
                {
                TypeModel model;
                if (card.CardType == "Attack")
                    {
                    model = TypeModel.Attack;
                    }
                else if (card.CardType == "Heal")
                    {
                    model = TypeModel.Heal;
                    }
                else if (card.CardType == "Deffence")
                    {
                    model = TypeModel.Deffence;
                    }
                else
                    {
                    model = TypeModel.Poison;
                    };
                cards.Add(
                      new CardModel
                          {
                          Id = card.Id,
                          Cost = card.Cost,
                          Name = card.Name,
                          Type = model,
                          Value = card.Value
                          }
                      );
                }
            foreach (CardServiceModel card in playerView.Deck.Cards)
                {
                TypeModel model;
                if (card.CardType == "Attack")
                    {
                    model = TypeModel.Attack;
                    }
                else if (card.CardType == "Heal")
                    {
                    model = TypeModel.Heal;
                    }
                else if (card.CardType == "Deffence")
                    {
                    model = TypeModel.Deffence;
                    }
                else
                    {
                    model = TypeModel.Poison;
                    };
                deck.Cards.Add
                      (
                      new CardModel
                          {
                          Id = card.Id,
                          Cost = card.Cost,
                          Type = model,
                          Name = card.Name,
                          Value = card.Value,
                          }
                      );
                }
            player = new PlayerModel
                {
                CardsInHeand = cards,
                Deck = deck,
                Name = playerName,

                };
            return player;
            }

        public async Task<List<CardServiceModel>> GetCardsInHand ()
            {
            List<CardServiceModel> cards = new();
            await this.GameManager.Update(GameEvents.StartTurn);
            if (this.GameManager.GetPlayerName() == this.GameManager.Player1.Name)
                {
                this.player.Name = this.GameManager.Player1.Name;
                foreach (CardModel card in this.GameManager.Player1.CardsInHeand)
                    {
                    cards.Add
                    (
                          new CardServiceModel
                              {
                              CardType = card.Type.ToString(),
                              Cost = card.Cost,
                              Id = card.Id,
                              // ImageUrl = this.data.Cards.FirstOrDefault(c => c.Id == card.Id).ImageUrl,
                              Name = card.Name,
                              Value = card.Value,
                              }
                    );
                    }

                }
            if (this.GameManager.GetPlayerName() == this.GameManager.Player2.Name)
                {
                this.player.Name = this.GameManager.Player2.Name;
                foreach (CardModel card in this.GameManager.Player2.CardsInHeand)
                    {
                    cards.Add
                    (
                          new CardServiceModel
                              {
                              CardType = card.Type.ToString(),
                              Cost = card.Cost,
                              Id = card.Id,
                              // ImageUrl = this.data.Cards.FirstOrDefault(c => c.Id == card.Id).ImageUrl,
                              Name = card.Name,
                              Value = card.Value,
                              }
                    );
                    }

                }
            return cards;
            }

        public async Task EndTurn ()
            {
            await this.GameManager.Update(GameEvents.EndTurn);

            if (this.GameManager.GetPlayerName() != "bot")
                {

                }
            else
                {
                }
            }
        }
    }
