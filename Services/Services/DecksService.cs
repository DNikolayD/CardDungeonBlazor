using System;
using System.Collections.Generic;
using System.Linq;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using Microsoft.EntityFrameworkCore;
using Services.ServiceModels.CardsModels;

namespace Services.Services
    {
    public class DecksService
        {
        private readonly ApplicationDbContext data;

        public DecksService ( ApplicationDbContext data )
            {
            this.data = data;
            }
        public void Add ( AddDecksServiceModel model )
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

        public List<CardTypeServiceModel> GetCardTypeViewModels ()
            {
            List<CardTypeServiceModel> cardTypeViewModel = new();
            DbSet<CardType> cardTypes = this.data.CardTypes;

            foreach (CardType cardType in cardTypes)
                {
                CardTypeServiceModel model = new()
                    {
                    Id = cardType.Id,
                    Name = cardType.Name
                    };
                cardTypeViewModel.Add(model);
                }
            return cardTypeViewModel;
            }

        public AllDecksServiceModel GetAll ()
            {
            AllDecksServiceModel allDecks = new();
            IQueryable<Deck> decks = this.data.Decks.Where(d => !d.IsDeleted);
            IQueryable<CardDeck> cards;
            Card card = new();
            string cardImage = string.Empty;

            foreach (Deck deck in decks)
                {
                cards = this.data.CardDecks.Where(x => x.DeckId == deck.Id);
                CardDeck cardDeck = cards.FirstOrDefault();
                card = this.data.Cards.FirstOrDefault(c => c.Id == cardDeck.CardId);
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

        public string GetId ( string name )
            {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Name == name);
            string deckId = deck.Id;
            return deckId;
            }

        public void Delete ( string id )
            {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Id == id);
            deck.IsDeleted = true;
            deck.DeletedOn = DateTime.UtcNow;
            this.data.Decks.Update(deck);
            this.data.SaveChanges();
            }

        public AddDecksServiceModel GetDeck ( string id )
            {
            Deck deck = this.data.Decks.FirstOrDefault(d => d.Id == id);

            AddDecksServiceModel model = new()
                {
                Name = deck.Name,
                DeckType = deck.DeckType,
                Description = deck.Description,
                };

            return model;
            }
        public void Edit ( string id, AddDecksServiceModel model )
            {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Id == id);
            deck.Name = model.Name;
            deck.DeckType = model.DeckType;
            deck.Description = model.Description;
            this.data.Decks.Update(deck);
            this.data.SaveChanges();
            }

        public FullDeckServiceModel GetFullDeckView ( string id )
            {
            Deck deck = this.data.Decks.FirstOrDefault(x => x.Id == id);
            IQueryable<CardDeck> cards = this.data.CardDecks.Where(cd => cd.DeckId == id);
            string createdOn = deck.CreatedOn.ToShortDateString();
            string type = deck.DeckType.ToString();
            FullDeckServiceModel model = new()
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
