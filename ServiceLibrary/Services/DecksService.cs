using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using ServiceLibrary.Interfaces;
using ServiceLibrary.MannualMapping;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Services
    {
    public class DecksService : IDecksService
        {

        private readonly ApplicationDbContext dbContext;

        public DecksService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public DeckServiceModel Add ( DeckServiceModel deckServiceModel )
            {
            Deck deck = MappingFromServiceToDb.DeckMapping(deckServiceModel);
            this.dbContext.Decks.Add(deck);
            this.dbContext.SaveChanges();
            return MappingFromDbToService.DeckMapping(deck);
            }

        public bool Delete ( string deckId )
            {
            Deck deck = this.dbContext.Decks.Find(deckId);
            deck.IsDeleted = true;
            deck.DeletedOn = DateTime.UtcNow;
            this.dbContext.Decks.Update(deck);
            this.dbContext.SaveChanges();
            return this.dbContext.Decks.Find(deck).IsDeleted;
            }

        public bool Edit ( DeckServiceModel deckServiceModel )
            {
            Deck deck = MappingFromServiceToDb.DeckMapping(deckServiceModel);
            Deck originaldeck = this.dbContext.Decks.Find(deckServiceModel.Id);
            IQueryable<CardDeck> cards = this.dbContext.CardDecks.Where(x => x.DeckId == deck.Id);
            deck.Cards = cards.ToList();
            originaldeck.Name = deck.Name;
            originaldeck.Description = deck.Description;
            this.dbContext.SaveChanges();
            return this.dbContext.Decks.Contains(deck);
            }

        public UserServiceModel GetUserByName ( string name )
            {
            ApplicationUser applicationUser = this.dbContext.Users.First(x => x.UserName == name);
            UserServiceModel userServiceModel = MappingFromDbToService.UserMapping(applicationUser);
            return userServiceModel;
            }

        public List<DeckServiceModel> Show ( string userName )
            {
            List<DeckServiceModel> deckServiceModels = new();
            IQueryable<Deck> Decks = this.dbContext.Decks.Where(x => x.CreatedByUserId == this.dbContext.Users.FirstOrDefault(x => x.UserName == userName).Id);
            foreach (Deck deck in Decks)
                {
                DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
                List<CardServiceModel> cardServiceModels = new();
                List<CardDeck> cardDecks = this.dbContext.CardDecks.Where(x => x.DeckId == deck.Id).ToList();
                foreach (CardDeck cardDeck in cardDecks)
                    {
                    Card card = this.dbContext.Cards.First(x => x.Id == cardDeck.CardId);
                    CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                    Image image = this.dbContext.Images.Find(card.ImageId);
                    CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
                    ApplicationUser applicationUser = this.dbContext.Users.Find(card.CreatedByUserId);
                    cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
                    cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
                    cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
                    cardServiceModels.Add(cardServiceModel);
                    }
                deckServiceModel.Cards = cardServiceModels;
                ApplicationUser user = this.dbContext.Users.FirstOrDefault(x => x.UserName == userName);
                UserServiceModel userServiceModel = MappingFromDbToService.UserMapping(user);
                deckServiceModel.CreatedByUser = userServiceModel;
                deckServiceModels.Add(deckServiceModel);
                }
            return deckServiceModels;
            }

        public DeckServiceModel ShowFull ( string deckId )
            {
            Deck deck = this.dbContext.Decks.Find(deckId);
            DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
            List<CardServiceModel> cardServiceModels = new();
            foreach (CardDeck cardDeck in deck.Cards)
                {
                Card card = this.dbContext.Cards.First(x => x.Id == cardDeck.CardId);
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                cardServiceModels.Add(cardServiceModel);
                }
            deckServiceModel.Cards = cardServiceModels;
            ApplicationUser user = this.dbContext.Users.FirstOrDefault(x => x.Id == deck.CreatedByUserId);
            UserServiceModel userServiceModel = MappingFromDbToService.UserMapping(user);
            deckServiceModel.CreatedByUser = userServiceModel;
            return deckServiceModel;
            }
        }
    }
