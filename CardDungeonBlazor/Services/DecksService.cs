using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDungeonBlazor.Services
{
    public class DecksService
    {
        private readonly ApplicationDbContext data;

        public DecksService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public void Add(AddDeckFormModel model)
        {
            Deck dbDeck = new()
            {
                Name = model.Name,
                Description = model.Description,
                DeckType = model.DeckType,
            };
            this.data.Decks.Add(dbDeck);
            this.data.SaveChanges();
        }

        public List<CardTypeViewModel> GetCardTypeViewModels()
        {
            List<CardTypeViewModel> cardTypeViewModel = new();
            DbSet<CardType> cardTypes = this.data.CardTypes;

            foreach (var cardType in cardTypes)
            {
                CardTypeViewModel model = new()
                {
                    Id = cardType.Id,
                    Name = cardType.Name
                };
                cardTypeViewModel.Add(model);
            }
            return cardTypeViewModel;
        }

        public AllDeckViewModel GetAll()
        {
            AllDeckViewModel allDecks = new();
            IQueryable<Deck> decks = data.Decks.Where(d => !d.IsDeleted);
            IQueryable<CardDeck> cards;
            Card card = new();
            string cardImage = string.Empty;

            foreach (var deck in decks)
            {
                cards = data.CardDecks.Where(x => x.DeckId == deck.Id);
                CardDeck cardDeck = cards.FirstOrDefault();
                card = data.Cards.FirstOrDefault(c => c.Id == cardDeck.CardId);
                cardImage = card.ImageUrl;
                DeckServiceModel model = new()
                {
                    Id = deck.Id,
                    Type = deck.DeckType.ToString(),
                    Name = deck.Name,
                    ImageUrl = cardImage,
                    Cards = cards.Count(),
                };
                allDecks.Decks.Add(model);
            }
            return allDecks;
        }

        public string GetId(string name)
        {
            Deck deck = data.Decks.FirstOrDefault(x => x.Name == name);
            string deckId = deck.Id;
            return deckId;
        }

        public void Delete(string id)
        {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Id == id);
            deck.IsDeleted = true;
            deck.DeletedOn = DateTime.UtcNow;
            this.data.Decks.Update(deck);
            this.data.SaveChanges();
        }

        public AddDeckFormModel GetDeck(string id)
        {
            Deck deck = this.data.Decks.FirstOrDefault(d => d.Id == id);

            AddDeckFormModel model = new()
            {
                Name = deck.Name,
                DeckType = deck.DeckType,
                Description = deck.Description,
            };

            return model;
        }
        public void Edit(string id, AddDeckFormModel model)
        {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Id == id);
            deck.Name = model.Name;
            deck.DeckType = model.DeckType;
            deck.Description = model.Description;
            this.data.Decks.Update(deck);
            data.SaveChanges();
        }

        public FullDeckViewModel GetFullDeckView(string id)
        {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Id == id);
            IQueryable<CardDeck> cards = data.CardDecks.Where(cd => cd.DeckId == id);
            string createdOn = deck.CreatedOn.ToShortDateString();
            string type = deck.DeckType.ToString(); 
            FullDeckViewModel model = new()
            {
                Name = deck.Name,
                Description = deck.Description,
                Type = type,
                CreatedOn = createdOn,
                NumberOfCards = cards.Count()
            };

            return model;
        }
    }
}
