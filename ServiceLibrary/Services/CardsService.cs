using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using Microsoft.AspNetCore.Identity;
using ServiceLibrary.Interfaces;
using ServiceLibrary.MannualMapping;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Services
    {
    public class CardsService : ICardsService
        {

        private readonly ApplicationDbContext dbContext;

        public CardsService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public bool Add ( CardServiceModel cardServiceModel )
            {
            Card card = MappingFromServiceToDb.CardMapping(cardServiceModel);
            Image image = MappingFromServiceToDb.ImageMapping(cardServiceModel.Image);
            this.dbContext.Images.Add(image);
            this.dbContext.SaveChanges();
            card.ImageId = image.Id;
            this.dbContext.Cards.Add(card);
            this.dbContext.SaveChanges();
            return this.dbContext.Cards.Contains(card);
            }

        public bool AddCardToDeck ( string cardId, string deckId )
            {
            Card card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            Deck deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == deckId);
            CardDeck cardDeck = new();
            cardDeck.CardId = cardId;
            cardDeck.DeckId = deckId;
            this.dbContext.CardDecks.Add(cardDeck);
            this.dbContext.SaveChanges();
            card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == deckId);
            return deck.Cards.Contains(cardDeck) && card.Decks.Contains(cardDeck);
            }

        public bool Delete ( string cardId )
            {
            Card card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            card.DeletedOn = DateTime.UtcNow;
            card.IsDeleted = true;
            this.dbContext.Cards.Update(card);
            this.dbContext.SaveChanges();
            card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            return card.IsDeleted;
            }

        public bool Edit ( CardServiceModel cardServiceModel )
            {
            Card card = MappingFromServiceToDb.CardMapping(cardServiceModel);
            IQueryable<CardDeck> decks = this.dbContext.CardDecks.Where(x => x.CardId == cardServiceModel.Id);
            card.Decks = decks.ToList();
            this.dbContext.Cards.Update(card);
            this.dbContext.SaveChanges();
            return this.dbContext.Cards.Contains(card);
            }

        public List<CardServiceModel> Show ( string userName )
            {
            List<CardServiceModel> cardServiceModels = new();
            IQueryable<Card> cards = this.dbContext.Cards.Where(x => x.CreatedByUserId == this.dbContext.Users.FirstOrDefault(x => x.UserName == userName).Id).Where(x => x.IsDeleted == false);
            foreach (Card card in cards)
                {
                List<DeckServiceModel> deckServiceModels = new();
                foreach (CardDeck cardDeck in card.Decks)
                    {
                    Deck deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == cardDeck.DeckId);
                    DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
                    deckServiceModels.Add(deckServiceModel);
                    }
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                cardServiceModel.Decks = deckServiceModels;
                ApplicationUser applicationUser = this.dbContext.Users.FirstOrDefault(x => x.Id == card.CreatedByUserId);
                Image image = this.dbContext.Images.FirstOrDefault(x => x.Id == card.ImageId);
                cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
                cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
                CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
                cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
                cardServiceModels.Add(cardServiceModel);
                }
            return cardServiceModels;
            }

        public CardServiceModel ShowFull ( string cardId )
            {
            Card card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            List<DeckServiceModel> deckServiceModels = new();
            foreach (CardDeck cardDeck in card.Decks)
                {
                Deck deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == cardDeck.DeckId);
                DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
                deckServiceModels.Add(deckServiceModel);
                }
            CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
            CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
            cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
            cardServiceModel.Decks = deckServiceModels;
            ApplicationUser applicationUser = this.dbContext.Users.FirstOrDefault(x => x.Id == card.CreatedByUserId);
            Image image = this.dbContext.Images.FirstOrDefault(x => x.Id == card.ImageId);
            cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
            cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
            return cardServiceModel;
            }

        public List<CardTypeServiceModel> ShowTypes ()
            {
            List<CardTypeServiceModel> cardTypeServiceModels = new();
            IQueryable<CardType> cardTypes = this.dbContext.CardTypes;
            foreach (CardType cardType in cardTypes)
                {
                CardTypeServiceModel cardTypeServiceModel = MappingFromDbToService.CardTypeMapping(cardType);
                cardTypeServiceModels.Add(cardTypeServiceModel);
                }
            return cardTypeServiceModels;
            }
        public UserServiceModel GetUserByName ( string name )
            {
            ApplicationUser applicationUser = this.dbContext.Users.First(x => x.UserName == name);
            UserServiceModel userServiceModel = MappingFromDbToService.UserMapping(applicationUser);
            return userServiceModel;
            }

        public List<CardServiceModel> ShowCardsInTheDeck ( string deckId )
            {
            List<CardServiceModel> cardServiceModels = new();
            Deck deck = this.dbContext.Decks.Find(deckId);
            foreach (CardDeck cardDeck in deck.Cards)
                {
                Card card = this.dbContext.Cards.First(x => x.Id == cardDeck.CardId);
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
                cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
                ApplicationUser applicationUser = this.dbContext.Users.FirstOrDefault(x => x.Id == card.CreatedByUserId);
                Image image = this.dbContext.Images.FirstOrDefault(x => x.Id == card.ImageId);
                cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
                cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
                cardServiceModels.Add(cardServiceModel);
                }
            return cardServiceModels;
            }

        public bool RemoveCardFromDeck ( string cardId, string deckId )
            {
            Card card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            Deck deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == deckId);
            CardDeck cardDeck = this.dbContext.CardDecks.FirstOrDefault(x => x.CardId == cardId && x.DeckId == deckId);
            card.Decks.Remove(cardDeck);
            deck.Cards.Remove(cardDeck);
            this.dbContext.SaveChanges();
            this.dbContext.Remove(cardDeck);
            card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == deckId);
            return deck.Cards.Contains(cardDeck) && card.Decks.Contains(cardDeck);
            }
        }
    }
