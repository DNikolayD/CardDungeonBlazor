using System;
using System.Collections.Generic;
using System.Linq;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using Microsoft.EntityFrameworkCore;
using Services.ServiceModels.CardsModels;

namespace Services.Services
    {
    public class CardsService
        {
        private readonly ApplicationDbContext data;

        public CardsService ( ApplicationDbContext data )
            {
            this.data = data;
            }

        public void Add ( AddCardsServiceModel model )
            {
            Card dbCard = new()
                {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                CardTypeId = model.CardTypeId,
                Description = model.Description,
                Value = model.Value,
                CreatedOn = DateTime.UtcNow,
                Cost = model.Cost,
                };
            this.data.Cards.Add(dbCard);
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

        public AllCardsServiceModel GetAllCards ()
            {
            AllCardsServiceModel allCards = new();
            IQueryable<Card> cards = this.data.Cards.Where(c => !c.IsDeleted);
            CardType cardType = new();
            foreach (Card card in cards)
                {
                cardType = this.data.CardTypes.FirstOrDefault(x => x.Id == card.CardTypeId);

                CardServiceModel model = new()
                    {
                    Id = card.Id,
                    CardType = cardType.Name,
                    Name = card.Name,
                    ImageUrl = card.ImageUrl,
                    Value = card.Value,
                    Cost = card.Cost,
                    };
                allCards.Cards.Add(model);
                }
            return allCards;
            }

        public void Delete ( string id )
            {
            Card dbCard = this.data.Cards.FirstOrDefault(c => c.Id == id);
            dbCard.IsDeleted = true;
            dbCard.DeletedOn = DateTime.UtcNow;
            this.data.Cards.Update(dbCard);
            this.data.SaveChanges();
            }

        public FullCardServiceModel GetFullCardView ( string id )
            {
            Card card = this.data.Cards.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            string createdOn = card.CreatedOn.ToShortDateString();
            int duration = 0;
            if (card.Duration.HasValue)
                {
                duration = card.Duration.Value;
                }

            FullCardServiceModel viewModel = new()
                {
                CardType = card.CardType.Name,
                CreatedOn = createdOn,
                Description = card.Description,
                Duration = duration,
                ImageUrl = card.ImageUrl,
                Name = card.Name,
                Value = card.Value,
                Cost = card.Cost,
                };

            return viewModel;
            }

        public AddCardsServiceModel GetEditFomModel ( string id )
            {
            Card card = this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            List<CardTypeServiceModel> cardTypeViewModel = this.GetCardTypeViewModels();

            AddCardsServiceModel model = new()
                {
                Name = card.Name,
                Description = card.Description,
                ImageUrl = card.ImageUrl,
                CardTypeId = card.CardTypeId,
                CardTypes = cardTypeViewModel,
                Value = card.Value,
                };

            return model;
            }

        public void Edit ( string id, AddCardsServiceModel cardModel )
            {
            Card dbCard = this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            dbCard.CardTypeId = cardModel.CardTypeId;
            dbCard.Description = cardModel.Description;
            dbCard.ImageUrl = cardModel.ImageUrl;
            dbCard.Name = cardModel.Name;
            dbCard.Value = cardModel.Value;
            dbCard.Cost = cardModel.Cost;
            dbCard.EditedOn = DateTime.UtcNow;
            dbCard.IsEdited = true;
            this.data.Cards.Update(dbCard);
            this.data.SaveChanges();
            }
        }
    }
