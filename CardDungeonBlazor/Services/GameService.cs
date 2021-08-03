using System;
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

        public void PlayCard(string cardId, string playerName, GameViewModel game)
        {
            PlayerModel player = this.GetPlayer(game, playerName);
            CardModel playedCard = player.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
            GameManager gameManager = new(this.GetPlayer(game, game.PlayerModel1.Name), this.GetPlayer(game, game.PlayerModel2.Name));
            gameManager.Update(GameEvents.SelectCard, new string[] { cardId });
        }
        public DeckViewModel GetDeck()
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
            return viewModel;
        }
       private PlayerModel GetPlayer(GameViewModel game, string playerName)
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
                TypeModel model = new();
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
    }
}
