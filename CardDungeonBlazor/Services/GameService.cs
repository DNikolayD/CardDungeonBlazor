using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardGame;
using CardGame.Models;

namespace CardDungeonBlazor.Services
    {
    public class GameService
        {
        private readonly ApplicationDbContext data;

        public GameService ( ApplicationDbContext data )
            {
            this.data = data;
            }

        public GameManager GameManager { get; set; }

        public async Task PlayCard ( string cardId, string playerName, GameViewModel game )
            {
            PlayerModel player = this.GetPlayer(game, playerName);
            CardModel playedCard = player.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
            await this.GameManager.Update(GameEvents.SelectCard, new string[] { cardId });
            game.PlayerModel1.Health = this.GameManager.player1.Health;
            game.PlayerModel2.Health = this.GameManager.player2.Health;
            game.PlayerModel1.Energy = this.GameManager.player1.Energy;
            game.PlayerModel2.Energy = this.GameManager.player2.Energy;
            }
        public DeckViewModel GetDeck ( string playerName )
            {
            DeckViewModel viewModel = new();
            IQueryable<CardDeck> deck = this.data.CardDecks.Where(cd => cd.DeckId == this.data.Decks.FirstOrDefault().Id);
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
                    Cost = 1,
                    ImageUrl = card.ImageUrl,
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
                if (cardService.CardType == "Deffence")
                    {
                    model = TypeModel.Deffence;
                    }
                else if (cardService.CardType == "Poison")
                    {
                    model = TypeModel.Poison;
                    };
                if (playerName == this.GameManager.player1.Name)
                    {
                    this.GameManager.player1.Deck.Cards.Add(
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
                    this.GameManager.player2.Deck.Cards.Add(
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
        public PlayerModel GetPlayer ( GameViewModel game,
                                                    string playerName )
            {
            PlayerModel player;
            PlayerViewModel playerView;
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
            PlayerModel player = this.GameManager.player;
            string type;
            foreach (CardModel card in player.CardsInHeand)
                {
                if (card.Type.CompareTo(TypeModel.Attack) == TypeModel.Attack.CompareTo(card.Type))
                    {
                    type = "Attack";
                    }
                else if (card.Type == TypeModel.Deffence)
                    {
                    type = "Deffence";
                    }
                else if (card.Type == TypeModel.Heal)
                    {
                    type = "Heal";
                    }
                else
                    {
                    type = "Poison";
                    }
                cards.Add
                (
                      new CardServiceModel
                          {
                          CardType = type,
                          Cost = card.Cost,
                          Id = card.Id,
                          ImageUrl = this.data.Cards.FirstOrDefault(c => c.Id == card.Id).ImageUrl,
                          Name = card.Name,
                          Value = card.Value,
                          }
                );
                }
            return cards;
            }

        public async Task EndTurn ()
            {
            await this.GameManager.Update(GameEvents.EndTurn);
            }
        }
    }
