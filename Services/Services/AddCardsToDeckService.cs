using System.Linq;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.ServiceModels.CardsModels;

namespace Services.Services
    {
    public class AddCardsToDeckService : IAddCardsToDeckService
        {
        private readonly ApplicationDbContext data;

        public AddCardsToDeckService ( ApplicationDbContext data )
            {
            this.data = data;
            }

        public AddCardsToDeckServiceModel GetAllCards ()
            {
            AddCardsToDeckServiceModel allCards = new();
            DbSet<Card> cards = this.data.Cards;
            foreach (Card card in cards)
                {
                CardAddedToTheDeckServiceModel model = new()
                    {
                    Id = card.Id,
                    Type = this.data.CardTypes.FirstOrDefault(x => x.Id == card.CardTypeId).Name,
                    Name = card.Name,
                    ImageUrl = card.ImageUrl,
                    Value = card.Value,
                    TimesAdded = 0,
                    };
                allCards.Cards.Add(model);
                }
            return allCards;
            }
        public void AddCardsToDeckWithId ( string cardId, string deckId )
            {
            Deck deck = this.data.Decks.FirstOrDefault(d => d.Id == deckId);
            CardDeck cardDeck = new()
                {
                CardId = cardId,
                DeckId = deckId,
                };
            this.data.CardDecks.Add(cardDeck);
            this.data.SaveChanges();
            deck.Cards.Add(cardDeck);
            this.data.Decks.Update(deck);
            this.data.SaveChanges();
            }
        }
    }
