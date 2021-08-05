﻿using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CardDungeonBlazor.Services
{
    public class AddCardsToDeckService
    {
        private readonly ApplicationDbContext data;

        public AddCardsToDeckService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public AddCardsToDeckModel GetAllCards()
        {
            AddCardsToDeckModel allCards = new();
            DbSet<Card> cards = data.Cards;
            foreach (var card in cards)
            {
                CardAddedToTheDeckViewModel model = new()
                {
                    Id = card.Id,
                    CardType = data.CardTypes.FirstOrDefault(x => x.Id == card.CardTypeId).Name,
                    Name = card.Name,
                    ImageUrl = card.ImageUrl,
                    Value = card.Value,
                    TimesAdded = 0,
                };
                allCards.Cards.Add(model);
            }
            return allCards;
        }
        public void AddCardsToDeckWithId(string cardId, string deckId)
        {
            Deck deck = data.Decks.FirstOrDefault(d => d.Id == deckId);
            CardDeck cardDeck = new()
            {
                CardId = cardId,
                DeckId = deckId,
            };
            data.CardDecks.Add(cardDeck);
            data.SaveChanges();
            deck.Cards.Add(cardDeck);
            data.Decks.Update(deck);
            data.SaveChanges();
        }
    }
}
