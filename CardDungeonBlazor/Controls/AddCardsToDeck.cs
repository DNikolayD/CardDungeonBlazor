using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Models;
using CardDungeonBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controls
{
    public class AddCardsToDeck
    {
        public AddCardsToDeckModel GetAllCards(ApplicationDbContext data)
        {
            AddCardsToDeckModel allCards = new();
            foreach (var card in data.Cards)
            {
                allCards.Cards.Add(new CardAddedToTheDeckViewModel
                {
                    Id = card.Id,
                    CardType = data.CardTypes.FirstOrDefault(x => x.Id == card.CardTypeId).Name,
                    Name = card.Name,
                    ImageUrl = card.ImageUrl,
                    Value = card.Value,
                    TimesAdded = 0,
                });
            }
            return allCards;
        }
        public void AddCardsToDeckWithId(ApplicationDbContext data, string cardId, string deckId)
        {
            data.CardDecks.Add(new CardDeck { CardId = cardId, DeckId = deckId });
            data.SaveChanges();
            CardDeck card = data.CardDecks.FirstOrDefault(x => x.DeckId == deckId);
            data.Decks.FirstOrDefault(x => x.Id == deckId).Cards.Add(card);
            data.SaveChanges();

        }

    }
    }

