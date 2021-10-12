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
            card.Decks.Add(cardDeck);
            deck.Cards.Add(cardDeck);
            this.dbContext.SaveChanges();
            card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            deck = this.dbContext.Decks.FirstOrDefault(x => x.Id == deckId);
            return deck.Cards.Contains(cardDeck) && card.Decks.Contains(cardDeck);
            }

        public bool Delete ( string cardId )
            {
            Card card = this.dbContext.Cards.FirstOrDefault(x => x.Id == cardId);
            card.IsDeleted = true;
            card.DeletedOn = DateTime.UtcNow;
            this.dbContext.Cards.Update(card);
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
            IQueryable<Card> cards = this.dbContext.Cards.Where(x => x.CreatedByUserId == this.dbContext.Users.FirstOrDefault(x => x.UserName == userName).Id);
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
            ApplicationUser applicationUser = this.dbContext.Users.First();
            string UserName = applicationUser.NormalizedUserName;
            UserServiceModel userServiceModel = MappingFromDbToService.UserMapping(applicationUser);
            return userServiceModel;
            }
        }
    }
