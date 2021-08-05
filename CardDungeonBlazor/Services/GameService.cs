using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Models;
using CardGame;
using CardGame.Models;

namespace CardDungeonBlazor.Services
{
    public class GameService
    {
        private readonly ApplicationDbContext data;

        public GameService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public GameManager GameManager { get; set; }

        public async Task PlayCard(string cardId, string playerName, GameViewModel game)
        {
            PlayerModel player = GetPlayer(game, playerName);
            CardModel playedCard = player.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
            await GameManager.Update(GameEvents.SelectCard, new string[] { cardId });
            game.PlayerModel1.Health = GameManager.player1.Health;
            game.PlayerModel2.Health = GameManager.player2.Health;
            game.PlayerModel1.Energy = GameManager.player1.Energy;
            game.PlayerModel2.Energy = GameManager.player2.Energy;
        }
        public DeckViewModel GetDeck(string playerName)
        {
            DeckViewModel viewModel = new();
            IQueryable<CardDeck> deck = this.data.CardDecks.Where(cd => cd.DeckId == this.data.Decks.FirstOrDefault().Id);
            foreach (var cardDeck in deck)
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
            foreach (var cardService in viewModel.Cards)
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
                else if(cardService.CardType == "Poison")
                {
                    model = TypeModel.Poison;
                };
                if (playerName == GameManager.player1.Name)
                {
                    GameManager.player1.Deck.Cards.Add(
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
                    GameManager.player2.Deck.Cards.Add(
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
        public PlayerModel GetPlayer(GameViewModel game,
                                      string playerName)
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
            foreach (var card in playerView.CardsInHeand)
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
                if (card.CardType == "Deffence")
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
            foreach (var card in playerView.Deck.Cards)
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
                if (card.CardType == "Deffence")
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

        public async Task<List<CardServiceModel>> GetCardsInHand()
        {
            List<CardServiceModel> cards = new();
            await GameManager.Update(GameEvents.StartTurn);
            PlayerModel player = GameManager.player;
            string type;
            foreach (var card in player.CardsInHeand)
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

        public async Task EndTurn()
        {
            await GameManager.Update(GameEvents.EndTurn);
        }
    }
}
